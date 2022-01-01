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
A recursive function is a construct in which the function calls itself.
