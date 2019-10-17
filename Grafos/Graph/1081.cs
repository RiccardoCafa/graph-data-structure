using Grafos.Graph.GenericGraph;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos.Graph
{
    
    class _1081
    {

    }
    public class Graph<T>
    {
        public List<Vertex<T>> Vertices { get; private set; }
        public bool Undirected { get; private set; }
        public int Size
        {
            get
            {
                return Vertices.Count;
            }
        }

        public Graph(bool undirected)
        {
            Vertices = new List<Vertex<T>>();
            this.Undirected = undirected;
        }

        public void AddArc(Vertex<T> vertex01, Vertex<T> vertex02, int weight = 1)
        {
            if (Undirected) throw new Exception("Grafo não dirigido");

            if (!Vertices.Contains(vertex01)) Vertices.Add(vertex01);
            if (!Vertices.Contains(vertex02)) Vertices.Add(vertex02);

            if (!vertex01.adj.ContainsKey(vertex02))
            {
                vertex01.AddEdge(vertex02, weight);
            }
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

        protected void DepthFirstSearch(Vertex<T> root)
        {
            UnvisitGraph();
            DFS(root);
        }

        protected void DFS(Vertex<T> root)
        {
            if (!root.IsOpen)
            {
                root.IsOpen = true;
                foreach (Vertex<T> v in root.adj.Keys)
                {
                    DFS(v);
                }
            }
        }

        public void BFS()
        {

        }

        public void Dijkstra(Vertex<T> root, out Dictionary<Vertex<T>, int> distancia)
        {
            UnvisitGraph();

            Dictionary<Vertex<T>, Vertex<T>> precessor = new Dictionary<Vertex<T>, Vertex<T>>();
            Dictionary<Vertex<T>, int> distancias = new Dictionary<Vertex<T>, int>();

            foreach (Vertex<T> ve in Vertices)
            {
                distancias.Add(ve, int.MaxValue);
            }
            distancias[root] = 0;
            precessor.Add(root, root);
            bool HasOpen = true;

            while (HasOpen)
            {
                root.IsOpen = true;
                foreach (KeyValuePair<Vertex<T>, int> ver in root.adj)
                {
                    if (!ver.Key.IsOpen && root.GetWeight(ver.Key) + distancias[root] < distancias[ver.Key])
                    {
                        distancias[ver.Key] = root.GetWeight(ver.Key) + distancias[root];
                        if (!precessor.ContainsKey(ver.Key)) precessor.Add(ver.Key, root);
                    }
                }
                root = null;
                foreach (KeyValuePair<Vertex<T>, int> dist in distancias)
                {
                    if (!dist.Key.IsOpen)
                    {
                        if (root == null)
                        {
                            root = dist.Key;
                        }
                        else if (root != null)
                        {
                            if (distancias[root] >= dist.Value)
                            {
                                root = dist.Key;
                            }
                        }
                    }
                }
                if (root == null) HasOpen = false;
            }
            distancia = distancias;
        }

        public void Topographic()
        {

        }

        private void UnvisitGraph()
        {
            foreach (Vertex<T> v in Vertices)
            {
                v.IsOpen = false;
            }
        }

    }
}
