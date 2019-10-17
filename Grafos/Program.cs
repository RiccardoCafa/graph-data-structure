﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Grafos.Graph.GenericGraph;

namespace Grafos
{
    class Program
    {
        public static Graph<int> graph;
        static void Main(string[] args)
        {
            Vertex<int>[] verts = new Vertex<int>[6]
            {
                new Vertex<int>(1),
                new Vertex<int>(2),
                new Vertex<int>(3),
                new Vertex<int>(4),
                new Vertex<int>(5),
                new Vertex<int>(6),
            };

            graph = new Graph<int>(false);

            graph.AddArc(verts[0], verts[1], 7);
            graph.AddArc(verts[0], verts[2], 8);
            graph.AddArc(verts[1], verts[0], 3);
            graph.AddArc(verts[1], verts[4], 4);
            graph.AddArc(verts[1], verts[5], 8);
            graph.AddArc(verts[2], verts[4], 10);
            graph.AddArc(verts[3], verts[2], 1);
            graph.AddArc(verts[4], verts[3], 9);
            graph.AddArc(verts[5], verts[3], 5);

            Dictionary<Vertex<int>, int> dists;

            graph.Dijkstra(verts[0], out dists);

            var items = from pair in dists
                        orderby pair.Key.Value ascending
                        select pair;

            foreach(KeyValuePair<Vertex<int>, int> pair in items)
            {
                Console.WriteLine(pair.Key.Value + " : " + pair.Value);
            }

        }

        public static void WrongEntry() => Console.WriteLine("Entrada inválida");

        public static void GraphTextEntry()
        {
            Console.WriteLine("\n\n1 X - Criar um " + (GraphType == 1 ? "Grafo" : "Digrafo") 
                                                    + " (sendo X o tamanho da matriz)\n");
            Console.WriteLine("2 - V1 V2 W - Criar uma aresta\n");
            Console.WriteLine("3 - V1 V2 Existe uma aresta\n");
            Console.WriteLine("4 - Tamanho do grafo em bytes (cuidado ao usar com grafos de ordem muito alta)");
        }

        public static bool GraphManager(string SE)
        {
            string[] Val = SE.Split(" ");
            int V1 = 0, V2 = 0, W = 0;

            int.TryParse(Val[0], out int Entry);
            if (Val.Length >= 2) int.TryParse(Val[1], out V1);
            if (Val.Length >= 3) int.TryParse(Val[2], out V2);
            if (Val.Length >= 4) int.TryParse(Val[3], out W);

            switch (Entry)
            {
                case 1:
                    int.TryParse(Val[1], out int tam);
                    if(GraphType == 1)
                    {
                        graphS = new GraphS(tam);
                    } else if(GraphType == 2)
                    {
                        graphS = new DigraphS(tam);
                    }

                    Console.WriteLine("Grafo criado. Tamanho: " + tam);
                    break;

                case 2:
                    if (graphS == null) WrongEntry();

                    graphS.AddEdge(V1, V2, W);

                    Console.WriteLine("\nVértice " + V1 + " " + (GraphType == 1 ? "---" : "-->") + " " + V2 + " com peso: " + graphS.GetWeight(V1, V2));

                    break;

                case 3:
                    if (graphS == null) WrongEntry();

                    if (graphS.ExistEdge(V1, V2))
                    {
                        Console.WriteLine("Existe a aresta: " + V1 + " " + (GraphType == 1 ? "---" : "-->") + " " + V2);
                    }
                    else
                    {
                        Console.WriteLine("Não existe a aresta: " + V1 + " " + (GraphType == 1 ? "---" : "-->") + " " + V2);
                    }

                    break;
                case 4:
                    if(graphS != null)
                    {
                        using(Stream s = new MemoryStream())
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            formatter.Serialize(s, graphS);
                            Console.WriteLine("Seu grafo tem \n\t| " + s.Length + " bit.");
                            Console.WriteLine("\t| " + (s.Length / 8) + " bytes.");
                            Console.WriteLine("\t| " + (s.Length / 8 / 1024) + " Kb.\n");
                        }
                    } else
                    {
                        Console.WriteLine("Grafo inexistente.\n");
                    }
                    break;
                default: WrongEntry(); return false;
            }
            return true;

            Console.Read();
        }
    }
}
