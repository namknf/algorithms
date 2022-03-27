# ALGORITHMS

## **Bynary Search**

### As an input, the algorithm accepts a sorted array of numbers and a number for search in class Alg. The output is the index of this number in the array.

There is only one method BynarySearch. The input parameters of the method are an array, the values of the boundaries of the list in which to search and a number to search.

**until that part shrinks to one element ... check the middle element**

```c#
while (low <= high)
{
    var mid = (low + high) / 2;
```

**value is founded(:**

```c#
if (searchVar == mid)
{
    return mid;
}
```

## Selection Sort

1. Find the smallest element in the array.

```c#
int result = n;
for (var i = n; i < array.Length; ++i)
{
    if (array[i] < array[result])
    {
        result = i;
    }
}

```

2. Change elements

```c#
var c = a;
a = b;
b = c;
```

3. And sort(^

```c#
if (smallestIndex == array.Length)
{
    return array;
}

var index = findSmallest(array, smallestIndex);

if (index != smallestIndex)
{
    Swap(ref array[index], ref array[smallestIndex]);
}

return SelSort(array, smallestIndex + 1);
```

## Recursion

### A recursive function is a construct in which the function calls itself.

According to the classics, I started with the implementation of the method for finding the factorial of a number:

```c#
public int Factorial(int x)
{
    if (x == 1)
    {
        return 1;
    }

    return x * Factorial(x - 1);
}
```

Further implemented a method for finding combinations of two numbers:

```c#
if ((m == 0) && (n > 0) || (m == n) && (n > 0))
{
    result = 1;
}
else if ((m > n) && (n >= 0))
{
    result = 0;
}
else
{
    result = Combinations(n - 1, m - 1) + Combinations(n - 1, m);
}

return result;
```

## Quick Sort

### QuickSort is a Divide and Conquer algorithm. It picks an element as pivot and partitions the given array around the picked pivot. Method Sort looks like:

```c#
if (low <= high)
{
    return array;
}

int pivotInd = Indexing(array, low, high);
Sort(array, low, pivotInd - 1);
Sort(array, pivotInd + 1, high);

return array;
```

## Breadth-First Search

### Breadth-first search (BFS) is an algorithm for searching a tree data structure for a node that satisfies a given property. It starts at the tree root and explores all nodes at the present depth prior to moving on to the nodes at the next depth level. Extra memory, usually a queue, is needed to keep track of the child nodes that were encountered but not yet explored.

To make the algorithm not so difficult to perceive, I made characters from the series "The Witcher" as nodes of the graph. There are classes WitcherCharacter, BreadthFirstSearch (it inherits from the class WitcherCharacter) and class Program for clarity.

## Dijkstra's Algorithm

### One algorithm for finding the shortest path from a starting node to a target node in a weighted graph is Dijkstra’s algorithm. The algorithm creates a tree of shortest paths from the starting vertex, the source, to all other points in the graph.

The main method of finding the shortest path is in the class Dijkstra.

```c#
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
```
