﻿using System.Linq;
using System.Threading.Tasks;
using fugu.graphql.error;

namespace fugu.graphql.execution
{
    public static class Mutation
    {
        public static async Task<ExecutionResult> ExecuteMutationAsync(
            QueryContext context)
        {
            var (schema, document, operation, initialValue, coercedVariableValues) = context;
            var executionContext = new ExecutorContext(
                schema,
                document,
                new SerialExecutionStrategy());

            var mutationType = schema.Mutation;
            if (mutationType == null)
                throw new GraphQLError(
                    "Schema does not support mutations. Mutation type is null.");

            var selectionSet = operation.SelectionSet;
            var path = new NodePath();
            var data = await SelectionSets.ExecuteSelectionSetAsync(
                executionContext,
                selectionSet,
                mutationType,
                initialValue,
                coercedVariableValues,
                path).ConfigureAwait(false);


            return new ExecutionResult
            {
                Errors = executionContext
                    .FieldErrors
                    .Select(context.FormatError).ToList(),
                Data = data
            };
        }
    }
}