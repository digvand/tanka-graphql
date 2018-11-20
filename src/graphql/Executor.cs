﻿using System;
using System.Linq;
using System.Threading.Tasks;
using fugu.graphql.execution;
using fugu.graphql.type;
using fugu.graphql.validation;
using GraphQLParser.AST;

namespace fugu.graphql
{
    public static class Executor
    {
        public static async Task<ExecutionResult> ExecuteAsync(ExecutionOptions options)
        {
            var extensions = new Extensions(options.Extensions);
            await extensions.BeginExecuteAsync(options);
            var logger = options.LoggerFactory.CreateLogger(typeof(Executor).FullName);

            using (logger.Begin(options.OperationName))
            {
                if (!options.Schema.IsInitialized)
                {
                    logger.SchemaNotInitialized();
                    await options.Schema.InitializeAsync().ConfigureAwait(false);
                }

                var operation = Operations.GetOperation(options.Document, options.OperationName);
                logger.Operation(operation);

                var coercedVariableValues = Variables.CoerceVariableValues(
                    options.Schema,
                    operation,
                    options.VariableValues);

                logger.Validate(options.Validate);
                if (options.Validate)
                {
                    await extensions.BeginValidationAsync();
                    var validationResult = await Validator.ValidateAsync(
                        options.Schema,
                        options.Document,
                        coercedVariableValues).ConfigureAwait(false);

                    logger.ValidationResult(validationResult);

                    await extensions.EndValidationAsync(validationResult);
                    if (!validationResult.IsValid)
                        return new ExecutionResult
                        {
                            Data = null,
                            Errors = validationResult.Errors.Select(e => new Error(e.Message)).ToList()
                        };
                }

                ExecutionResult executionResult;
                switch (operation.Operation)
                {
                    case OperationType.Query:
                        executionResult = await Query.ExecuteQueryAsync(
                            options.FormatError,
                            options.Document,
                            operation,
                            options.Schema,
                            coercedVariableValues,
                            options.InitialValue).ConfigureAwait(false);
                        break;
                    case OperationType.Mutation:
                        executionResult = await Mutation.ExecuteMutationAsync(
                            options.FormatError,
                            options.Document,
                            operation,
                            options.Schema,
                            coercedVariableValues,
                            options.InitialValue).ConfigureAwait(false);
                        break;
                    case OperationType.Subscription:
                        throw new InvalidOperationException($"Use {nameof(SubscribeAsync)}");
                    default:
                        throw new InvalidOperationException($"Operation type {operation.Operation} not supported.");
                }

                logger.ExecutionResult(executionResult);
                await extensions.EndExecuteAsync(executionResult);
                return executionResult;
            }
        }

        public static async Task<SubscriptionResult> SubscribeAsync(ExecutionOptions options)
        {
            var logger = options.LoggerFactory.CreateLogger(typeof(Executor).FullName);

            using (logger.Begin(options.OperationName ?? "(unknown)"))
            {
                if (!options.Schema.IsInitialized)
                {
                    logger.SchemaNotInitialized();
                    await options.Schema.InitializeAsync().ConfigureAwait(false);
                }

                var operation = Operations.GetOperation(options.Document, options.OperationName);
                logger.Operation(operation);

                var coercedVariableValues = Variables.CoerceVariableValues(
                    options.Schema,
                    operation,
                    options.VariableValues);

                logger.Validate(options.Validate);
                if (options.Validate)
                {
                    var result = await Validator.ValidateAsync(
                        options.Schema,
                        options.Document,
                        coercedVariableValues).ConfigureAwait(false);

                    logger.ValidationResult(result);
                    if (!result.IsValid)
                        return new SubscriptionResult
                        {
                            Errors = result.Errors.Select(e => new Error(e.Message)).ToList()
                        };
                }

                switch (operation.Operation)
                {
                    case OperationType.Subscription:
                        return await Subscription.SubscribeAsync(
                            options.FormatError,
                            options.Document,
                            operation,
                            options.Schema,
                            coercedVariableValues,
                            options.InitialValue).ConfigureAwait(false);
                    default:
                        throw new InvalidOperationException(
                            $"Operation type {operation.Operation} not supported. Did you mean to use {nameof(ExecuteAsync)}?");
                }
            }
        }
    }
}