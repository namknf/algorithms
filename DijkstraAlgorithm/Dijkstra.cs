namespace Algorithms
{
    using System.Collections.Generic;

    internal class Dijkstra
    {
        private Graph _graph;

        private List<GraphVertexInformation> _infos;

        public Dijkstra(Graph graph)
        {
            _graph = graph;
        }

        // Finding the shortest path by vertex names
        public string FindShortestPath(string startName, string finishName)
        {
            return FindShortestPath(_graph.FindVertex(startName), _graph.FindVertex(finishName));
        }

        // Information initialization
        private void InitInfo()
        {
            _infos = new List<GraphVertexInformation>();

            foreach (var v in _graph.Vertices)
            {
                _infos.Add(new GraphVertexInformation(v));
            }
        }

        // Getting information about the top of the graph
        private GraphVertexInformation GetVertexInfo(GraphVertex v)
        {
            foreach (var i in _infos)
            {
                if (i.Vertex.Equals(v))
                {
                    return i;
                }
            }

            return null;
        }

        // Finding an unvisited vertex with a minimum sum value
        private GraphVertexInformation FindUnvisitedVertexWithMinSum()
        {
            var minValue = int.MaxValue;
            GraphVertexInformation minVertexInfo = null;

            foreach (var i in _infos)
            {
                if (i.IsUnVisited && i.EdgesSum < minValue)
                {
                    minVertexInfo = i;
                    minValue = i.EdgesSum;
                }
            }

            return minVertexInfo;
        }

        // Finding the shortest path along the vertices
        private string FindShortestPath(GraphVertex startVertex, GraphVertex finishVertex)
        {
            InitInfo();
            var first = GetVertexInfo(startVertex);
            first.EdgesSum = 0;

            while (true)
            {
                var current = FindUnvisitedVertexWithMinSum();
                if (current == null)
                {
                    break;
                }

                SetSumToNextVertex(current);
            }

            return GetPath(startVertex, finishVertex);
        }

        // Calculating the sum of the edge weights for the next vertex
        private void SetSumToNextVertex(GraphVertexInformation info)
        {
            info.IsUnVisited = false;
            foreach (var e in info.Vertex.Edges)
            {
                var nextInfo = GetVertexInfo(e.ConnectedVertex);
                var sum = info.EdgesSum + e.EdgeWeight;
                if (sum < nextInfo.EdgesSum)
                {
                    nextInfo.EdgesSum = sum;
                    nextInfo.PreviousVertex = info.Vertex;
                }
            }
        }

        // Path formation 
        private string GetPath(GraphVertex startVertex, GraphVertex endVertex)
        {
            var path = endVertex.ToString();
            while (startVertex != endVertex)
            {
                endVertex = GetVertexInfo(endVertex).PreviousVertex;
                path = endVertex.ToString() + path;
            }

            return path;
        }
    }
}