﻿using System.Diagnostics;
using GraphQLParser.AST;

namespace fugu.graphql.validation
{
    public class DebugNodeVisitor : INodeVisitor
    {
        public void Enter(ASTNode node)
        {
            Debug.WriteLine($"Entering {node}");
        }

        public void Leave(ASTNode node)
        {
            Debug.WriteLine($"Leaving {node}");
        }
    }
}