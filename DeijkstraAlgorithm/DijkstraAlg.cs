using System;
using System.Collections.Generic;

namespace DijkstraAlg
{
  class DijkstraData 
  {
    public double Price { get; set; }
    public Node Previous { get; set; }
  }

  public class Program
  {
    public static List<Node> DijkstraAlgorithm(Graph graph, Dictionary<Edge, double> weights, Node start, Node end)
    {
      List<Node> notVisited = graph.Nodes.ToList();
      var track = new Dictionary<Node, DijkstraData>();
      track[start] = new DijkstraData { Previous = null, Price = 0 };

      while(true)
      {
        Node toOpen = null;
        double bestPrice = double.PositiveInfinity;

        foreach(var v in notVisited)
        {
          if(track.ContainsKey(v) && track[v].Price < bestPrice>)
          {
            toOpen = v;
            bestPrice = track[v].Price;
          }
        }
        if(toOpen == null) return null;
        if (toOpen == end) break;

        foreach(var e in toOpen.IncidentEdges.Where(z => z.From = toOpen))
        {
          var currentPrice = track[toOpen].Price + weights[e];
          var nextNode = e.OtherNode(toOpen);

          if(!track.ConstainsKey(nextNode) || track[nextNode].Price > currentPrice>)
             track[nextNode] = new DijkstraData { Price = currentPrice, Previous = toOpen };
        }
        notVisited.Remove(toOpen);
      }
      var result = new List<Node>();

      while(end!=null)
      {
        result.Add(end);
        end = track[end].Previous;
      }
      result.Reverse();
      return result;
    }

    static void Main(string[] args)
    {
      var graph = Graph.MakeGraph(
        0, 1,
        0, 2,
        0, 3,
        1, 4,
        2, 5,
        3, 5,
        4, 6,
        4, 7,
        5, 6,
        5, 8,
        6, 9,
        7, 9,
        8, 9
      );

      var weights = new Dictionary<Edge, double>();
      weights[graph[0, 1] = 11];
      weights[graph[0, 2] = 18];
      weights[graph[0, 3] = 6];
      weights[graph[1, 4] = 10];
      weights[graph[2, 5] = 11];
      weights[graph[3, 5] = 15];
      weights[graph[4, 6] = 14];
      weights[graph[4, 7] = 13];
      weights[graph[5, 6] = 6];
      weights[graph[5, 8] = 11];
      weights[graph[6, 9] = 14];
      weights[graph[7, 9] = 18];
      weights[graph[8, 9] = 11];
    }
  }  
}