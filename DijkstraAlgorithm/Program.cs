namespace Algorithms
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var g = new Graph();

            // adding vertexes
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");
            g.AddVertex("D");
            g.AddVertex("E");
            g.AddVertex("F");
            g.AddVertex("G");

            // adding edges
            g.AddEdge("A", "B", 22);
            g.AddEdge("A", "C", 33);
            g.AddEdge("A", "D", 61);
            g.AddEdge("B", "C", 47);
            g.AddEdge("B", "E", 93);
            g.AddEdge("C", "D", 11);
            g.AddEdge("C", "E", 79);
            g.AddEdge("C", "F", 63);
            g.AddEdge("D", "F", 41);
            g.AddEdge("E", "F", 17);
            g.AddEdge("E", "G", 58);
            g.AddEdge("F", "G", 84);

            var dijkstra = new Dijkstra(g);
            var path = dijkstra.FindShortestPath("A", "G");
            Console.WriteLine(path);
        }
    }
}