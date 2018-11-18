﻿using System.Collections.Generic;
using fugu.graphql.error;
using fugu.graphql.type;
using GraphQLParser.AST;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace fugu.graphql
{
    public class ExecutionOptions
    {
        public ISchema Schema { get; set; }

        public GraphQLDocument Document { get; set; }

        public string OperationName { get; set; }

        public Dictionary<string, object> VariableValues { get; set; }

        public object InitialValue { get; set; }

        public IErrorTransformer ErrorTransformer { get; set; } = new DefaultErrorTransformer();

        public bool Validate { get; } = true;

        public ILoggerFactory LoggerFactory { get; set; } = new NullLoggerFactory();
    }
}