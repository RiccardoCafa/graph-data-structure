using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos.Graph
{
    class _1855
    {
        class URI_1855
        {
            static void Main(string[] args)
            {
                Graph<Vector> mapa = new Graph<Vector>();
                int largura, altura;
                largura = int.Parse(Console.ReadLine());
                altura = int.Parse(Console.ReadLine());
                Vertex<Vector>[,] vertx = new Vertex<Vector>[altura, largura];
                for (int i = 0; i < altura; i++)
                {
                    string line = Console.ReadLine();
                    for (int j = 0; j < largura; j++)
                    {
                        vertx[i, j] = new Vertex<Vector>(new Vector(i, j, line[j]));
                    }
                }
                bool foundTreasure = false;
                Vector posInit = new Vector(0, 0, vertx[0, 0].Value.valor);
                Vector dir = Vector.right;

                for (int i = 0; i < altura; i++)
                {
                    for (int j = 0; j < largura; j++)
                    {
                        //enfiar as arestas
                    }
                }

                if (foundTreasure)
                {
                    Console.WriteLine("*");
                }
                else
                {
                    Console.WriteLine("!");
                }

                Console.ReadLine();
            }
        }

        class Vector
        {
            public int x;
            public int y;
            public char valor;

            public static Vector right = new Vector(0, 1);
            public static Vector left = new Vector(0, -1);
            public static Vector up = new Vector(-1, 0);
            public static Vector down = new Vector(1, 0);
            // 0 - >
            // 1 - <
            // 2 - ^
            // 3 - v
            // 4 - .
            // 5 - *

            public Vector(int x, int y, char valor = '.')
            {
                this.x = x;
                this.y = y;
                this.valor = valor;
            }
        }

        class Graph<T>
        {
            public List<Vertex<T>> Vertices { get; private set; }
            public bool Undirected { get; private set; }

            public Graph()
            {
                Vertices = new List<Vertex<T>>();
                this.Undirected = true;
            }

            public void AddEdge(Vertex<T> vertex01, Vertex<T> vertex02, int weight = 1)
            {
                if (!Undirected) throw new Exception("Grafo dirigido");

                if (!Vertices.Contains(vertex01)) Vertices.Add(vertex01);
                if (!Vertices.Contains(vertex02)) Vertices.Add(vertex02);

                if (!vertex01.adj.ContainsKey(vertex02))
                {
                    vertex01.AddEdge(vertex02, weight);
                    vertex02.AddEdge(vertex01, weight);
                }
            }

            private List<Vertex<T>> visitados;

            public void DepthFirstSearch(Vertex<T> root, out List<Vertex<T>> visits)
            {
                UnvisitGraph();
                visitados = new List<Vertex<T>>();
                DFSwCam(root);
                visits = visitados;
            }

            protected void DFSwCam(Vertex<T> root)
            {
                if (!root.IsOpen)
                {
                    visitados.Add(root);
                    root.IsOpen = true;
                    foreach (Vertex<T> v in root.adj.Keys)
                    {
                        DFSwCam(v);
                    }
                }
            }

            private void UnvisitGraph()
            {
                foreach (Vertex<T> v in Vertices)
                {
                    v.IsOpen = false;
                }
            }

        }

        class Vertex<T>
        {
            public Dictionary<Vertex<T>, int> adj { get; set; }
            public T Value { get; set; }
            public bool IsOpen { get; set; }

            public Vertex(T value)
            {
                adj = new Dictionary<Vertex<T>, int>();
                this.Value = value;
            }

            public void AddEdge(Vertex<T> vertex, int weight = 1)
            {
                adj.Add(vertex, weight);
            }
        }
    }
}
