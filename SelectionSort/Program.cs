namespace SelectionSort
{
    using System;

    class Program
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

        static int[] SelSort(int[] array, int currentIndex = 0)
        {
            if (currentIndex == array.Length)
            {
                return array;
            }

            var index = findSmallest(array, currentIndex);

            if (index != currentIndex)
            {
                Swap(ref array[index], ref array[currentIndex]);
            }

            return SelSort(array, currentIndex + 1);
        }

        static void Main(string[] args)
        {
            int[] array = { 2, 3, 4, 6, 8, 10, 2, 0, 1, 1 };
            Console.WriteLine(string.Join(", ", SelSort(array)));
        }
    }
}
