namespace Algorithms
{
    internal class GraphEdge
    {
        public GraphEdge(GraphVertex connectedVertex, int weight)
        {
            ConnectedVertex = connectedVertex;
            EdgeWeight = weight;
        }

        public GraphVertex ConnectedVertex { get; }

        public int EdgeWeight { get; }
    }
}