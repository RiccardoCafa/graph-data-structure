using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos.Graph
{
    [System.Serializable]
    class DigraphS : StaticGraph
    {
        public DigraphS(int M) : base(M) { }

        public override void AddEdge(int Vertex01, int Vertex02, int Weight)
        {
            Adj[Vertex01, Vertex02] += Weight;
        }

        public override bool ExistEdge(int Vertex01, int Vertex02)
        {
            return Adj[Vertex01, Vertex02] > 0;
        }

        public override int GetWeight(int Vertex01, int Vertex02)
        {
            return Adj[Vertex01, Vertex02];
        }
    }
}
