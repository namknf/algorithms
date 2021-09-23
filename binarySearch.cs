using System;
using Collections.Generic;

namespace algorithms
{
    class Program
    {
        static void Main()
        {
            BinarySearch();
        }
    }

    class Alg()
    {
        public void BinarySearch(int[] array, int searchVar, int low, int high)
        {
           while(low <= high)
           {
               var mid = (low + high)/2;

               if(searchVar == mid)
               {
                   return mid;
               }
               else if(searchVar < mid)
               {
                   high = mid - 1;
               }
               else
               {
                   low = mid + 1;
               }
           }
           return -1;
        }
    }
}