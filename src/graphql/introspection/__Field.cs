﻿using System;
using System.Collections.Generic;
using fugu.graphql.type;

namespace fugu.graphql.introspection
{
    public class __Field
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<__InputValue> Args { get; set; }

        public IGraphQLType Type { get; set; }

        public bool IsDeprecated { get; set; }

        public string DeprecationReason { get; set; }
    }
}