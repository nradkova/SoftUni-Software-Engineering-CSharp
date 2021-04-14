using System;
using System.Collections.Generic;
using System.Linq;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>
                (Console.ReadLine()
                .Split()
                .Select(int.Parse));
            Queue<int> scarfs = new Queue<int>
                (Console.ReadLine()
                .Split()
                .Select(int.Parse));
            List<int> sets = new List<int>();

            var hat = hats.Peek();
            var scarf = scarfs.Peek();
            while (hats.Count>0&&scarfs.Count>0)
            {
                if (hat > scarf)
                {
                    sets.Add(hat + scarf);
                    scarfs.Dequeue();
                    hats.Pop();
                    if (scarfs.Count > 0)
                    {
                        scarf = scarfs.Peek();
                    }
                    if (hats.Count > 0)
                    {
                        hat = hats.Peek();
                    }
                }
                else if (scarf > hat)
                {
                    hats.Pop();
                    if (hats.Count > 0)
                    {
                        hat = hats.Peek();
                    }
                }
                else if(scarf==hat)
                {
                    hat++;
                    scarfs.Dequeue();
                    if (scarfs.Count > 0)
                    {
                        scarf = scarfs.Peek();
                    }
                }
            }
            Console.WriteLine($"The most expensive set is: " +
                $"{sets.Max()}");
            Console.WriteLine(string.Join(" ",sets));
        }
    }
}
