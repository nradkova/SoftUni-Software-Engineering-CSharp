using System;
using System.Dynamic;
using System.Linq;

namespace _1.ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] input = Console.ReadLine().Split();
            ListyIterator<string> list =
                new ListyIterator<string>(input.Skip(1).ToArray());
            
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;

                    case "Print":
                        list.Print();
                        break;

                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;

                    case "PrintAll":
                        foreach (var item in list)
                        {
                            Console.Write(item+" ");
                        }
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
