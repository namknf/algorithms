namespace DejkstraAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Graph_E
    {
        public class Edge
        {
            public readonly Node _from;
            public readonly Node _to;

            public Edge(Node first, Node second)
            {
                _from = first;
                _to = second;
            }

            public bool IsIncident(Node node)
            {
                return _from == node || _to == node;
            }

            public Node OtherNode(Node node)
            {
                if (!IsIncident(node))
                {
                    throw new ArgumentException();
                }

                if (_from == node)
                {
                    return _to;
                }

                return _from;
            }
        }

        public class Node
        {
            private readonly List<Edge> _edges = new List<Edge>();

            private readonly int _nodeNumber;

            public Node(int number)
            {
                _nodeNumber = number;
            }

            public static IEnumerable<Node> Nodes
            {
                get
                {
                    foreach (var node in Nodes)
                    {
                        yield return node;
                    }
                }
            }

            public static IEnumerable<Edge> Edges
            {
                get
                {
                    return Nodes.SelectMany(z => z.IncidentEdges).Distinct();
                }
            }

            public IEnumerable<Node> IncidentNodes
            {
                get
                {
                    return _edges.Select(z => z.OtherNode(this));
                }
            }

            public IEnumerable<Edge> IncidentEdges
            {
                get
                {
                    foreach (var e in _edges)
                    {
                        yield return e;
                    }
                }
            }

            public static Edge Connect(Node node1, Node node2, Graph graph)
            {
                if (!graph.Node.Contains(node1) || !graph.Node.Contains(node2))
                {
                    throw new ArgumentException();
                }

                var edge = new Edge(node1, node2);

                node1._edges.Add(edge);
                node2._edges.Add(edge);

                return edge;
            }

            public static void Disconnect(Edge edge)
            {
                edge._from._edges.Remove(edge);
                edge._to._edges.Remove(edge);
            }
        }

        public class Graph
        {
            private Node[] _nodes;

            public Graph(int nodesCount)
            {
                _nodes = Enumerable.Range(0, nodesCount).Select(z => new Node(z)).ToArray();
            }

            public int Length => _nodes.Length;

            public Node this[int index]
            {
                get { return _nodes[index]; }
            }

            public static Graph MakeGraph(params int[] incidentNodes)
            {
                var graph = new Graph(incidentNodes.Max() + 1);

                for (int i = 0; i < incidentNodes.Length - 1; i += 2)
                {
                    graph.Connect(incidentNodes[i], incidentNodes[i + 1]);
                }

                return graph;
            }

            public void Connect(int index1, int index2)
            {
                Node.Connect(_nodes[index1], _nodes[index2], this);
            }

            public void Delete(Edge edge)
            {
                Node.Disconnect(edge);
            }
        }
    }
}