using System;
using System.Collections.Generic;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            Queue<string> numbers = new Queue<string>
                (Console.ReadLine().Split());
            Queue<string> webSites = new Queue<string>
                (Console.ReadLine().Split());
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            Dialling(numbers, smartphone, stationaryPhone);
            Browsing(webSites, smartphone);
        }

        private static void Browsing(Queue<string> webSites, Smartphone smartphone)
        {
            while (webSites.Count > 0)
            {
                string webSite = webSites.Dequeue();
                Console.WriteLine(smartphone.BrowseWeb(webSite));
            }
        }

        private static void Dialling(Queue<string> numbers, Smartphone smartphone, StationaryPhone stationaryPhone)
        {
            while (numbers.Count > 0)
            {
                string number = numbers.Dequeue();
                if (number.Length !=7 &&number.Length!=10)
                {
                    Console.WriteLine("Invalid number!");
                }
                if (number.Length == 7)
                {
                    Console.WriteLine(stationaryPhone.MakeCalls(number));
                }
                if (number.Length == 10)
                {
                    Console.WriteLine(smartphone.MakeCalls(number));
                }
            }
        }
    }
}
