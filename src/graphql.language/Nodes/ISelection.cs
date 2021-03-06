﻿using System.Collections.Generic;

namespace Tanka.GraphQL.Language.Nodes
{
    public interface ISelection: INode
    {
        public SelectionType SelectionType { get; }
        
        public IReadOnlyCollection<Directive>? Directives { get; }
    }
}