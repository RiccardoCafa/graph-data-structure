using System;
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

            Console.WriteLine("Dijkstra:");

            Dictionary<Vertex<int>, int> dists;

            graph.Dijkstra(verts[0], out dists);

            var items = from pair in dists
                        orderby pair.Key.Value ascending
                        select pair;

            foreach(KeyValuePair<Vertex<int>, int> pair in items)
            {
                Console.WriteLine(pair.Key.Value + " : " + pair.Value);
            }

            Console.WriteLine("BFS: ");

            List<Vertex<int>> list = graph.BFS(verts[0]);

            list.Sort();
            foreach(Vertex<int> )

            Console.Read();
        }
    }
}
