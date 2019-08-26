using Grafos.Graph;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos.Graph
{
    [System.Serializable]
    public abstract class StaticListGraph
    {
        public List<Vertice> vertices;
        public abstract void AddEdge(int Vertex01, int Vertex02);

        public abstract bool ExistEdge(int Vertex01, int Vertex02);

        public abstract int GetWeight(int Vertex01, int Vertex02);

    }
}
