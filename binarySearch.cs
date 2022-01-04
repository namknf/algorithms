namespace Algorithms
{
    using System;

    internal class Alg
    {
        public int BinarySearch(int[] array, int searchVar, int low, int high)
        {
            while (low <= high)
            {
                var mid = (low + high) / 2;

                if (searchVar == mid)
                {
                    return mid;
                }
                else if (searchVar < mid)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return 0;
        }
    }
}
