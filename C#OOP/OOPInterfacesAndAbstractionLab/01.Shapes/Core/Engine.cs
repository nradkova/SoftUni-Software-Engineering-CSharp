using System;
using System.Collections.Generic;
using System.Text;

using Shapes.Contracts;
using Shapes.Models;

namespace Shapes.Core
{
    public class Engine
    {
        public Engine()
        {

        }
        public void Run()
        {
            var radius = int.Parse(Console.ReadLine());
            IDrawable circle = new Circle(radius);

            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            IDrawable rect = new Rectangle(width, height);

            circle.Draw();
            rect.Draw();
        }
    }
}
