# ALGORITHMS

## **Bynary Search**

As an input, the algorithm accepts a sorted array of numbers and a number for search. The output is the index of this number in the array.
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
