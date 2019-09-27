﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Tanka.GraphQL.Channels;
using Tanka.GraphQL.SchemaBuilding;
using Tanka.GraphQL.SDL;
using Tanka.GraphQL.Tools;
using Tanka.GraphQL.TypeSystem;
using Tanka.GraphQL.ValueResolution;

namespace Tanka.GraphQL.Server.Tests.Host
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var eventManager = new EventManager();
            var sdl = @"
                input InputEvent {
                    type: String!
                    message: String!
                }

                type Event {
                    type: String!
                    message: String!
                }

                type Query {
                    hello: String!
                }

                type Mutation {
                    add(event: InputEvent!): Event
                }

                type Subscription {
                    events: Event!
                }

                schema {
                    query: Query
                    mutation: Mutation
                }
                ";

            var builder = new SchemaBuilder()
                .Sdl(Parser.ParseDocument(sdl));

            var resolvers = new ObjectTypeMap
            {
                {
                    "Event", new FieldResolversMap
                    {
                        {"type", Resolve.PropertyOf<Event>(ev => ev.Type)},
                        {"message", Resolve.PropertyOf<Event>(ev => ev.Message)}
                    }
                },
                {
                    "Query", new FieldResolversMap
                    {
                        {"hello", context => new ValueTask<IResolveResult>(Resolve.As("world"))}
                    }
                },
                {
                    "Mutation", new FieldResolversMap
                    {
                        {
                            "add", async context =>
                            {
                                var input = context.GetArgument<InputEvent>("event");
                                var ev = await eventManager.Add(input.Type, input.Message);

                                return Resolve.As(ev);
                            }
                        }
                    }
                },
                {
                    "Subscription", new FieldResolversMap
                    {
                        {
                            "events", (context, ct) =>
                            {
                                var events = eventManager.Subscribe(ct);
                                return new ValueTask<ISubscribeResult>(events);
                            },
                            context => new ValueTask<IResolveResult>(Resolve.As(context.ObjectValue))
                        }
                    }
                }
            };

            var executable = SchemaTools.MakeExecutableSchemaWithIntrospection(
                builder,
                resolvers,
                resolvers);

            services.AddSingleton(provider => executable);
            services.AddSingleton(provider => eventManager);

            // web socket server
            services.AddTankaSchemaOptions()
                .Configure<ISchema>((options, schema) => options.GetSchema = query => new ValueTask<ISchema>(schema));

            services.AddTankaWebSocketServer();
            services.AddSignalR(options => { options.EnableDetailedErrors = true; })
                .AddNewtonsoftJsonProtocol()
                .AddTankaServerHub();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseWebSockets();
            app.UseTankaWebSocketServer();

            app.UseRouting();
            app.UseEndpoints(routes =>
            {
                routes.MapTankaServerHub("/graphql");
            });
        }
    }

    public class Event
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }

    public class InputEvent
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }

    public class EventManager
    {
        private readonly PoliteEventChannel<Event> _channel;

        public EventManager()
        {
            _channel = new PoliteEventChannel<Event>(new Event
            {
                Type = "welcome",
                Message = "Welcome"
            });
        }

        public async Task<Event> Add(string type, string message)
        {
            var ev = new Event
            {
                Type = type,
                Message = message
            };
            await _channel.WriteAsync(ev);
            return ev;
        }

        public ISubscribeResult Subscribe(CancellationToken cancellationToken)
        {
            return _channel.Subscribe(cancellationToken);
        }
    }
}