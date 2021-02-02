using System;

namespace _05._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Person[] people = new Person[n];
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                people[i] = new Person(input[0], int.Parse(input[1]));
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            Func<Person, bool> sortDelegate = SortByAge(condition,age);
            Action<Person> print = PrintResult(command);
            SortingResults(people, sortDelegate, print);

            //SortingResults(people, p => p.Name.Length > 3, p => { Console.WriteLine(p.Name); });
        }
        static void SortingResults(Person[] people,
            Func<Person, bool> sort,
             Action<Person> print)
        {
            foreach (var person in people)
            {
                if (sort(person))
                {
                    print(person);
                }
            }
        }

        static Func<Person, bool> SortByAge(string condition, int age)
        {
                if (condition == "younger")
                {
                    return p=>p.Age<age;
                }
                if (condition == "older")
                {
                    return p=>p.Age >= age;
                }
            return null;
        }

        static Action<Person> PrintResult(string command)
        {
            if (command == "name")
            {
               return  p =>
                {
                    Console.WriteLine(p.Name);
                };
                
            }
            if (command == "age")
            {
                return p =>
                {
                    Console.WriteLine(p.Age);
                };
            }
            if (command == "name age")
            {
                return p =>
                {
                    Console.WriteLine(p.Name+" - "+p.Age);
                };
            }
            return null;
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
        }
    }
}

