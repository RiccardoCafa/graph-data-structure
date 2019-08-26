using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos.Graph
{
    public class Vertice
    {
        public List<int> Aresta = new List<int>();
        public int vert;
        public Vertice(int valor,int aresta)
        {
            vert = valor;
            Aresta.Add(aresta);
        }

    }
}
