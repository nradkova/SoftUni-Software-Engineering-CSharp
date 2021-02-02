using System;

namespace _04.GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                box.Add(double.Parse(Console.ReadLine()));
            }
            Console.WriteLine(box.CountGreater(double.Parse(Console.ReadLine())));


            //int n = int.Parse(Console.ReadLine());
            //Box<string> box = new Box<string>();

            //for (int i = 0; i < n; i++)
            //{
            //    box.Add(Console.ReadLine());
            //}
            //Console.WriteLine(box.CountGreater(Console.ReadLine()));
        }
    }
}
