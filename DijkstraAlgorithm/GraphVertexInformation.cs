namespace Algorithms
{
    internal class GraphVertexInformation
    {
        public GraphVertexInformation(GraphVertex vertex)
        {
            Vertex = vertex;
            IsUnVisited = true;
            EdgesSum = int.MaxValue;
            PreviousVertex = null;
        }

        public GraphVertex Vertex { get; set; }

        public bool IsUnVisited { get; set; }

        public int EdgesSum { get; set; }

        public GraphVertex PreviousVertex { get; set; }
    }
}