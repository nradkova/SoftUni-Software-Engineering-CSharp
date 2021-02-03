using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _06.EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> people = new HashSet<Person>();
            SortedSet<Person> peopleSorted = new SortedSet<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person person = new Person(input[0]
                    , int.Parse(input[1]));
               
                people.Add(person);
                peopleSorted.Add(person);
            }

            Console.WriteLine(peopleSorted.Count);
            Console.WriteLine(people.Count);
        }
    }
}
