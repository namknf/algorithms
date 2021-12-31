namespace Algorithms
{
    using System;

    class SelectionSort
    {
        static int findSmallest(int[] array, int n)
        {
            int result = n;
            for (var i = n; i < array.Length; ++i)
            {
                if (array[i] < array[result])
                {
                    result = i;
                }
            }

            return result;
        }

        static void Swap(ref int a, ref int b)
        {
            var c = a;
            a = b;
            b = c;
        }

        static int[] SelSort(int[] array, int smallestIndex = 0)
        {
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
        }
    }
}
