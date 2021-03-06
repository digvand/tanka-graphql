using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tanka.GraphQL.Extensions.Analysis;
using Tanka.GraphQL.Extensions.Tracing;
using Tanka.GraphQL.Samples.Chat.Data;
using Tanka.GraphQL.Samples.Chat.Web.GraphQL;
using Tanka.GraphQL.Server;
using Tanka.GraphQL.Server.Links.DTOs;
using Tanka.GraphQL.TypeSystem;
using Tanka.GraphQL.Validation;

namespace Tanka.GraphQL.Samples.Chat.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // required to serialize 
                    options.JsonSerializerOptions.Converters
                        .Add(new ObjectDictionaryConverter());
                });

            // graphql
            services.AddSingleton<IChat, Data.Chat>();
            services.AddSingleton<IChatResolverService, ChatResolverService>();
            services.AddSingleton<ChatSchemas>();
            services.AddSingleton(provider => provider.GetRequiredService<ChatSchemas>().Chat);

            // configure execution options
            services.AddTankaGraphQL()
                .ConfigureRules(rules => rules.Concat(new[]
                {
                    CostAnalyzer.MaxCost(100, 1, true)
                }).ToArray())
                .ConfigureSchema<ISchema>(schema => new ValueTask<ISchema>(schema))
                .AddExtension<TraceExtension>()
                .ConfigureWebSockets();
                

            // signalr server
            services.AddSignalR(options => options.EnableDetailedErrors = true)
                .AddTankaGraphQL();

            // graphql-ws websocket server
            // web socket server
            services.AddWebSockets(options =>
            {
                options.AllowedOrigins.Add("https://localhost:5000");
                options.AllowedOrigins.Add("https://localhost:3000");
            });

            // CORS is required for the graphql.samples.chat.ui React App
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:3000");
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowCredentials();
                    policy.WithHeaders("X-Requested-With", "authorization");
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseWebSockets();

            // websockets server
            app.UseTankaGraphQLWebSockets("/api/graphql");

            // signalr server
            app.UseRouting();
            app.UseEndpoints(routes =>
            {
                routes.MapTankaGraphQLSignalR("/graphql");
                routes.MapControllers();
            });
        }
    }
}