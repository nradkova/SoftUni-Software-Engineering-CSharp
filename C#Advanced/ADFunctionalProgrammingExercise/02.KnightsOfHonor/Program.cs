using System;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string[]> print =
                array =>
            {
                foreach (var name in array)
                {
                    Console.WriteLine($"Sir {name}");
                }
            };

            print(names);
        }
    }
}
