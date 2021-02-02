using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person("Pesho", 20);
            Console.WriteLine($"{firstPerson.Name} {firstPerson.Age}");
            Person secondPerson = new Person("Gosho", 18);
            Console.WriteLine($"{secondPerson.Name} {secondPerson.Age}");
            Person thirdPerson = new Person("Stamat", 43);
            Console.WriteLine($"{thirdPerson.Name} {thirdPerson.Age}");

        }
    }
}
