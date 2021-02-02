using System;

namespace _02.RecursivaFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            long n =long.Parse(Console.ReadLine());
           
            Console.WriteLine(CalcFactorial(n));
        }

        private static long CalcFactorial(long n)
        {
            if (n==0)
            {
                return 1;
            }
            return n * CalcFactorial(n - 1);
        }
    }
}
