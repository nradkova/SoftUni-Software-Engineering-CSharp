using System;
using Vehicles.Core;
using Vehicles.Core.Contract;

namespace Vehicles
{
   public class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
