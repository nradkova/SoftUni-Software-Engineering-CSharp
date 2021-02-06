using System;

namespace Shapes
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Shape c = new Circle(3);
            Shape r = new Rectangle(3,5);
            Console.WriteLine(c.CalculateArea());

            Console.WriteLine(c.Draw());
            Console.WriteLine(r.Draw());
        }
    }
}
