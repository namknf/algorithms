namespace Algorithms.Library
{
    internal class Recursion
    {
        public int Factorial(int x)
        {
            if (x == 1)
            {
                return 1;
            }

            return x * Factorial(x - 1);
        }

        public int Combinations(int m, int n)
        {
            int result = 0;

            if (((m == 0) && n > 0) || ((m == n) && (n > 0)))
            {
                result = 1;
            }
            else if ((m > n) && (n >= 0))
            {
                result = 0;
            }
            else
            {
                result = Combinations(n - 1, m - 1) + Combinations(n - 1, m);
            }

            return result;
        }
    }
}