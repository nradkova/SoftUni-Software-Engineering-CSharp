using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string dateStart =Console.ReadLine();
            string dateEnd =Console.ReadLine();

            DateModifier modifier = new DateModifier(dateStart, dateEnd);
            Console.WriteLine(modifier.Difference);
        }
    }
}
