# ALGORITHMS

## **Bynary Search**

As an input, the algorithm accepts a sorted array of numbers and a number for search in class Alg. The output is the index of this number in the array.
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
For testing:
```c#
static void Main()
{
    Alg test = new Alg();

    int[] array = new int[] { 2, 4, 6, 8, 10, 12 };
    int searchRes = 6;
    int result = test.BinarySearch(array, searchRes, 0, array.Length - 1);

    Console.WriteLine($"Result is: {result}");
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
For testing:
```c#
private static void Main()
{
    SlectionSort test = new SelectionSort();
    int[] result = test.SelSort({1, 5, 2, 7, 3}); // 1, 2, 3, 5, 7
}
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

For testing:
```c#
private static void Main()
{
    AlgFactroial test = new AlgFactroial();

    int resultFac = test.Factorial(8);
    int resultCom = test.Combinations(6, 4);

    Console.WriteLine($"Factorial = {resultFac}, Combinations = {resultCom}");
}
```

## Quick Sort
