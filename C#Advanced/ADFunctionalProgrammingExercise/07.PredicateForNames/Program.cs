using System;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Func<string, bool> filter = x => x.Length <= n;

            foreach (var name in names)
            {
                if (filter(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
