using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers =Console.ReadLine().Split()
                .Select(int.Parse)
                .Reverse()
                .ToArray();
            int n =int.Parse(Console.ReadLine());

            Func<int, bool> filter = x => x % n !=0;
            numbers = numbers.Where(filter).ToArray();
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
