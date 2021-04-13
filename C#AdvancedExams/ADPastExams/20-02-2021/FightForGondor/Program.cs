using System;
using System.Collections.Generic;
using System.Linq;

namespace _200221
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            Queue<int> plates
                = new Queue<int>(Console.ReadLine()
                .Split().Select(int.Parse));
            Stack<int> orcs = null;
            bool peopleWin = false;
            bool orcsWin = false;
            for (int i = 1; i <= waves; i++)
            {
                orcs = new Stack<int>(Console.ReadLine()
                       .Split().Select(int.Parse));

                if (i % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                var plate = plates.Peek();
                while (orcs.Count > 0 && plates.Count > 0)
                {
                    var orc = orcs.Pop();
                    if (orc == plate)
                    {
                        plates.Dequeue();
                    }
                    else if (orc > plate)
                    {
                        orc -= plate;
                        orcs.Push(orc);
                        plates.Dequeue();
                        if (plates.Count > 0)
                        {
                            plate = plates.Peek();
                        }
                    }
                    else if (plate > orc)
                    {
                        plate -= orc;
                        if (orcs.Count > 0)
                        {
                            orc = orcs.Peek();
                        }
                    }
                }
                if (plates.Count == 0)
                {
                    orcsWin = true;
                    break;
                }
                if (i == waves && orcs.Count == 0)
                {
                    peopleWin = true;
                }
            }


            if (orcsWin)
            {
                Console.WriteLine("The orcs successfully" +
                    " destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
            if (peopleWin)
            {
                Console.WriteLine("The people successfully" +
                    " repulsed the orc's attack.");
                Console.WriteLine($"Plates  left: {string.Join(", ", plates)}");
            }
        }
    }
}
