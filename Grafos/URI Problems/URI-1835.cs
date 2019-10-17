using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace uri1835
{
class URI_1835
{
    static void Maina(string[] args)
    {
        Promessa();

    }

    public static void Promessa()
    {
        int casos;
        int arestas, vertices;
        int count = 0;
        casos = int.Parse(Console.ReadLine());//Console.ReadLine()
        Graph<int> graph;
        for (int i = 0; i < casos; i++)
        {
            count = 0;
            graph = new Graph<int>(true);
            vertices = int.Parse(Console.ReadLine());
            arestas = int.Parse(Console.ReadLine());
            Vertex<int>[] vertxs = new Vertex<int>[vertices];
            for (int k = 0; k < vertices; k++)
            {
                vertxs[k] = new Vertex<int>(k);
                graph.Vertices.Add(vertxs[k]);
            }
            for (int j = 0; j < arestas; j++)
            {
                string[] valores = Console.ReadLine().Split(' ');
                int val1 = int.Parse(valores[0]);
                int val2 = int.Parse(valores[1]);
                graph.AddEdge(vertxs[val1 - 1], vertxs[val2 - 1]);
            }

            if (arestas == 0)
            {
                Console.WriteLine("Caso #" + (i + 1) + ": ainda falta(m) " + (vertices - 1) + " estrada(s)");
                continue;
            }

            List<Vertex<int>> lista = graph.BFS(graph.Vertices[0]);

            bool HasOpen = true;
            if (lista.Count == vertices)
            {
                Console.WriteLine("Caso #" + (i + 1) + ": a promessa foi cumprida");
            }
            else
            {
                while (HasOpen)
                {
                    var verticesAbertos = from v in graph.Vertices
                                          where v.IsOpen == false
                                          select v;
                    if (verticesAbertos.Count() == 0) { HasOpen = false; break; }

                    count++;

                    graph.BFS(verticesAbertos.First());
                }
                Console.WriteLine("Caso #" + (i + 1) + ": ainda falta(m) " + count + " estrada(s)");
            }
        }
    }
}

public class Graph<T>
{
    public List<Vertex<T>> Vertices { get; private set; }
    public bool Undirected { get; private set; }

    public Graph(bool undirected)
    {
        Vertices = new List<Vertex<T>>();
        this.Undirected = undirected;
    }

    public void AddEdge(Vertex<T> vertex01, Vertex<T> vertex02, int weight = 1)
    {
        if (!Undirected) throw new Exception("Grafo dirigido");

        if (!Vertices.Contains(vertex01)) Vertices.Add(vertex01);
        if (!Vertices.Contains(vertex02)) Vertices.Add(vertex02);

        if (!vertex01.adj.ContainsKey(vertex02))
        {
            vertex01.AddEdge(vertex02, weight);
        }

        if (!vertex02.adj.ContainsKey(vertex01))
        {
            vertex02.AddEdge(vertex01, weight);
        }
    }

    public List<Vertex<T>> BFS(Vertex<T> root)
    {
        List<Vertex<T>> opened = new List<Vertex<T>>();
        Queue<Vertex<T>> myQueue = new Queue<Vertex<T>>();

        myQueue.Enqueue(root);

        while (myQueue.Count > 0)
        {
            Vertex<T> vert = myQueue.Dequeue();

            vert.IsOpen = true;

            if (opened.Contains(vert))
            {
                continue;
            }

            opened.Add(vert);

            foreach (Vertex<T> v in vert.adj.Keys)
            {
                if (!opened.Contains(v)) myQueue.Enqueue(v);
            }
        }

        return opened;
    }

}

public class Vertex<T>
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