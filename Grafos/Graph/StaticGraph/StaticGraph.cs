using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos.Graph.StaticGraph
{
    [System.Serializable]
    public abstract class StaticGraph
    {
        public int Edges { get; }
        public int Vertices { get; }

        protected int[,] Adj;

        public StaticGraph(int M)
        {
            Adj = new int[M, M];
        }

        public abstract void AddEdge(int Vertex01, int Vertex02, int Weight);

        public abstract bool ExistEdge(int Vertex01, int Vertex02);

        public abstract int GetWeight(int Vertex01, int Vertex02);

    }
}
