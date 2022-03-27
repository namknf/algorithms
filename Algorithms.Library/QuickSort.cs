namespace Algorithms.Library
{
    internal class QuickSort
    {
        public int[] Sort(int[] array)
        {
            return Sort(array, 0, array.Length - 1);
        }

        public int[] Sort(int[] array, int low, int high)
        {
            if (low <= high)
            {
                return array;
            }

            var pivotInd = Indexing(array, low, high);

            Sort(array, low, pivotInd - 1);
            Sort(array, pivotInd + 1, high);

            return array;
        }

        private void Swap(ref int a, ref int b) // for changing elements
        {
            (a, b) = (b, a);
        }

        private int Indexing(int[] array, int low, int high)
        {
            var pivot = low - 1;

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
    }
}