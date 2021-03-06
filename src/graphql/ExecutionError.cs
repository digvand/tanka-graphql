﻿using System.Collections.Generic;
using Tanka.GraphQL.Language.Nodes;

namespace Tanka.GraphQL
{
    public class ExecutionError
    {
        public ExecutionError()
        {
            // required by System.Text.Json deserialization
        }

        public string Message { get; set; }

        public List<Location> Locations { get; set; }

        public List<object> Path { get; set; }

        public Dictionary<string, object> Extensions { get; set; }

        public void Extend(string key, object value)
        {
            if (Extensions == null)
                Extensions = new Dictionary<string, object>();

            Extensions[key] = value;
        }
    }
}