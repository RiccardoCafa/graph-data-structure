using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos.Graph.GenericGraph
{
    public class Graph<T>
    {
        public List<Vertex<T>> Vertices { get; private set; }
        public bool Undirected { get; private set; }
        public int Size {
            get {
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

        private List<Vertex<T>> visitados;
        private Dictionary<Vertex<T>, int> visitadosCam;

        public void DepthFirstSearch(Vertex<T> root, out List<Vertex<T>> visits)
        {
            UnvisitGraph();
            visitados = new List<Vertex<T>>();
            DFSwCam(root);
            visits = visitados;
        }

        public void DepthFirstSearch(Vertex<T> root, out Dictionary<Vertex<T>, int> visits)
        {
            UnvisitGraph();
            cam = 0;
            visitados = new List<Vertex<T>>();
            DFSwCam(root);
            visits = visitadosCam;
        }

        protected void DFSwCam(Vertex<T> root)
        {
            if(!root.IsOpen)
            {
                visitados.Add(root);
                root.IsOpen = true;
                foreach(Vertex<T> v in root.adj.Keys)
                {
                    DFSwCam(v);
                }
            }
        }

        private int cam = 0;
        protected void DFSCam(Vertex<T> root)
        {
            if (!root.IsOpen)
            {
                visitadosCam.Add(root, cam);
                root.IsOpen = true;
                cam++;
                foreach (Vertex<T> v in root.adj.Keys)
                {
                    DFSCam(v);
                }
            }
        }

        public List<Vertex<T>> BFS(Vertex<T> root)
        {
            List<Vertex<T>> opened = new List<Vertex<T>>();
            Queue<Vertex<T>> myQueue = new Queue<Vertex<T>>();

            myQueue.Enqueue(root);

            while(myQueue.Count > 0)
            {
                Vertex<T> vert = myQueue.Dequeue();

                if(opened.Contains(vert))
                {
                    continue;
                }

                opened.Add(vert);

                foreach(Vertex<T> v in vert.adj.Keys)
                {
                    if(!opened.Contains(v)) myQueue.Enqueue(v);
                }
            }

            return opened;
        }

        public void Dijkstra(Vertex<T> root, out Dictionary<Vertex<T>, int> distancia)
        {
            UnvisitGraph();

            Dictionary<Vertex<T>, Vertex<T>> precessor = new Dictionary<Vertex<T>, Vertex<T>>();
            Dictionary<Vertex<T>, int> distancias = new Dictionary<Vertex<T>, int>();

            foreach(Vertex<T> ve in Vertices)
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
                        if(!precessor.ContainsKey(ver.Key)) precessor.Add(ver.Key, root);
                    }
                }
                root = null;
                foreach(KeyValuePair<Vertex<T>, int> dist in distancias)
                {
                    if (!dist.Key.IsOpen)
                    {
                        if(root == null)
                        {
                            root = dist.Key;
                        } else if(root != null)
                        {
                            if(distancias[root] >= dist.Value)
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
            foreach(Vertex<T> v in Vertices)
            {
                v.IsOpen = false;
            }
        }

    }
}
