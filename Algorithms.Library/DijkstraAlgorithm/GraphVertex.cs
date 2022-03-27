namespace Algorithms.Library.DijkstraAlgorithm
{
    using System.Collections.Generic;

    internal class GraphVertex
    {
        public GraphVertex(string vertexName)
        {
            Name = vertexName;
            Edges = new List<GraphEdge>();
        }

        public string Name { get; }

        public List<GraphEdge> Edges { get; }

        public override string ToString() => Name;

        public void AddEdge(GraphEdge newEdge)
        {
            Edges.Add(newEdge);
        }

        public void AddEdge(GraphVertex vertex, int edgeWeight)
        {
            AddEdge(new GraphEdge(vertex, edgeWeight));
        }
    }
}
