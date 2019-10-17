using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos.Graph
{
    class Q1835
    {
        static void Main(string[] args)
        {


        }


        public void Promessa()
        {
            int casos;
            int arestas, vertices;
            int count = 0;
            casos = int.Parse(Console.ReadLine());
            for (int i = 0; i < casos; i++)
            {
                vertices = int.Parse(Console.ReadLine());
                arestas = int.Parse(Console.ReadLine());
                int[,] lig = new int[arestas,2];
                for (int j = 0; j < arestas; j++)
                {
                    string[] valores = Console.ReadLine().Split(' ');
                    lig[j, 0] = int.Parse(valores[0]);
                    lig[j, 1] = int.Parse(valores[1]);
                }
                Console.WriteLine("Caso #"+i+": a promessa foi cumprida");
                Console.WriteLine("Caso #" + i + ": ainda falta(m) " + count + " estrada(s)");
            }
        }

    }
}
