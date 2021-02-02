using System;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Func<string, int> sumOfChars = name => name.Select(c => (int)c).Sum();
                //x =>
                //{
                //    int sum = 0;
                //    for (int i = 0; i < x.Length; i++)
                //    {
                //        sum += x[i];
                //    }
                //    return sum;
                //};
            Func<string, int, bool> condition = (x, y) => sumOfChars(x) >= y;
            string result = names.First(x=>condition(x,number));
            Console.WriteLine(result);
        }
    }
}
