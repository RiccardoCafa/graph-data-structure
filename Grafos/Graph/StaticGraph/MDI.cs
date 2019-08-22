using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos.Graph
{
    class MDI: StaticGraph
    {
        public MDI(int v,int a) : base(v)
        {
            Adj = new int[v, a];
        }
        public override void AddEdge(int Vertex01, int Vertex02, int Aresta)
        {
            ConectAresta(Vertex01, Aresta);
            ConectAresta(Vertex02, Aresta);
        }
        public void ConectAresta(int vertice,int aresta) 
        {
            Adj[vertice, aresta] = 1;
        }
        public override bool ExistEdge(int Vertex01, int Vertex02)
        {
            for (int i = 0; i < Adj[Vertex01,i]; i++)
            {
                if(Adj[Vertex01,i] == 1)
                {
                    if (Adj[Vertex02, i] == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override int GetWeight(int Vertex01, int Vertex02)
        {
            int aux = 0;
            if (ExistEdge(Vertex01, Vertex02)==false)
            {
                return aux;
            }
            for (int i = 0; i < Adj[Vertex01, i]; i++)
            {
                if (Adj[Vertex01, i] == 1)
                {
                    if (Adj[Vertex02, i] == 1)
                    {
                        aux ++;
                    }
                }
            }
            return aux;
        }
    }
}
