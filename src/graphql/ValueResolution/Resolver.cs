﻿using System.Threading.Tasks;

namespace Tanka.GraphQL.ValueResolution
{
    public delegate ValueTask<IResolveResult> Resolver(ResolverContext context);
}