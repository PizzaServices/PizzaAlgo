﻿using System.Collections.Generic;
using Algorithms.Graphs.EdgeWeightedDirected;

namespace Algorithms.Graphs.Directed
{
    public class Topological
    {
        private readonly IEnumerable<int> order;

        public Topological(Digraph digraph)
        {
            var cycleFinder = new DirectedCycle(digraph);

            if (cycleFinder.HasCycle()) 
                return;

            var dfs = new DepthFirstOrder(digraph);
            order = dfs.ReversePost();
        }

        public Topological(EdgeWeightedDigraph graph)
        {
            var finder = new EdgeWeightedDirectedCycle(graph);

            if (finder.HasCycle()) 
                return;

            DepthFirstOrder dfs = new DepthFirstOrder(graph);
            order = dfs.ReversePost();
        }

        public IEnumerable<int> Order()
        {
            return order;
        }

        public bool HasOrder()
        {
            return order != null;
        }
    }
}
