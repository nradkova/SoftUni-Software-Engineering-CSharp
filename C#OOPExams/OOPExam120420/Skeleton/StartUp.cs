using CounterStrike.Core;
using CounterStrike.Core.Contracts;
using System;

namespace CounterStrike
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
