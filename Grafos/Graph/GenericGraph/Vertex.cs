using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Grafos.Graph.GenericGraph
{
    public class Vertex<T>
    {
        public Dictionary<Vertex<T>, int> adj { get; }
        public T Value { get; set; }
        public bool IsOpen { get; set; }
        public int AdjCount {
            get {
                return adj.Count;
            }
        }
        public List<Vertex<T>> adjList {
            get {
                return adj.Keys.ToList();
            }
        }

        public Vertex(T value, Dictionary<Vertex<T>, int> adjac = null)
        {
            adj = adjac ?? new Dictionary<Vertex<T>, int>();
            this.Value = value;
        }

        public void AddEdge(Vertex<T> vertex, int weight = 1)
        {
            adj.Add(vertex, weight);
        }

        public int GetWeight(Vertex<T> vertex02)
        {
            if (adj.Keys.Contains(vertex02))
            {
                return adj[vertex02];
            }
            return int.MaxValue;
        }

        public void RemoveEdge(Vertex<T> vertex)
        {
            adj.Remove(vertex);
        }

        public void RemoveEdgeByValue(T value)
        {
            Vertex<T> v = adj.First(ve => ve.Key.Value.Equals(value)).Key;
            if(v != null) adj.Remove(v);
        }
    }
}
