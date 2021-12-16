namespace Algorithms
{
    using System;
    
    internal class Alg()
    {
        public void BinarySearch(int[] array, int searchVar, int low, int high)
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
            
           return -1;
        }
    }
    
    class Program
    {
        static void Main()
        {
            Alg test = new Alg();
            
            int[] array = new int[] {2, 4, 6, 8, 10, 12};
            
            int searchRes = 6;
   
            test.BinarySearch(array, searchRes, 0, array.Length - 1);
        }
    }
}
