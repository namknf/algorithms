namespace Algorithms.Library
{
    public class SelectionSort
    {
        public static int[] SelSort(int[] array, int smallestIndex = 0)
        {
            if (smallestIndex == array.Length)
            {
                return array;
            }

            var index = FindSmallest(array, smallestIndex);

            if (index != smallestIndex)
            {
                Swap(ref array[index], ref array[smallestIndex]);
            }

            return SelSort(array, smallestIndex + 1);
        }

        private static int FindSmallest(int[] array, int n)
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

        private static void Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }
    }
}
