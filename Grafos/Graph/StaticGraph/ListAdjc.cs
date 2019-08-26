using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos.Graph
{
    class ListAdjc : StaticListGraph
    {
        
        public override void AddEdge(int Vertex01, int Vertex02)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if(vertices[i].vert == Vertex01)
                {
                    vertices[i].Aresta.Add(Vertex02);
                }
            }
            Vertice novovertice = new Vertice(Vertex01, Vertex02);
            vertices.Add(novovertice);
        }

        public override bool ExistEdge(int Vertex01, int Vertex02)
        {
            Vertice v = vertices.Find(x => x.vert == Vertex01 && x.Aresta.Contains(Vertex02));
            if (v != null){

                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetWeight(int Vertex01, int Vertex02)
        {
            int count= 0;
            for (int i = 0; i < vertices[Vertex01].Aresta.Count; i++)
            {
                if(vertices[Vertex01].Aresta[i] == Vertex02)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
