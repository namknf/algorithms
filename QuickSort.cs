namespace Algorithms
{
    using System;

    internal class QuickSort
    {
        private void Swap(ref int a, ref int b) // for changing elements
        {
            var c = a;
            a = b;
            b = c;
        }

        private int Indexing(int[] array, int low, int high)
        {
            int pivot = low - 1;

            for (int i = low; i < high; i++)
            {
                if (array[i] < array[high])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[high]);

            return pivot;
        }

        public int[] Sort(int[] array, int low, int high)
        {
            if (low <= high)
            {
                return array;
            }

            int pivotInd = Indexing(array, low, high);
            Sort(array, low, pivotInd - 1);
            Sort(array, pivotInd + 1, high);

            return array;
        }

        public int[] Sort(int[] array)
        {
            return Sort(array, 0, array.Length - 1);
        }
    }