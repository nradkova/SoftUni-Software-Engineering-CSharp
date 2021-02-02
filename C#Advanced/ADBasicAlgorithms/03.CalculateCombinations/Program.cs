using System;

namespace CalculateCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long r = long.Parse(Console.ReadLine());

            long firstPart = CalcFactorial(n);
            long secondPart = CalcFactorial(r) * CalcFactorial(n - r);
            long combinations = firstPart / secondPart;
            Console.WriteLine(combinations);
            Console.WriteLine(CalcFactorial(n));
        }

        private static long CalcFactorial(long n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n * CalcFactorial(n - 1);
        }
       
    }
}
