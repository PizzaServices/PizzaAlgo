﻿namespace Algorithms.Tries.Ukkonen
{
    internal class Edge<T>
    {
        public Edge(string label, Node<T> target)
        {
            this.Label = label;
            this.Target = target;
        }

        public string Label { get; set; }

        public Node<T> Target { get; private set; }
    }
}
