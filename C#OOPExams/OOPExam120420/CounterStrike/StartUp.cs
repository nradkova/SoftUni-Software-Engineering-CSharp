using CounterStrike.Core;
using CounterStrike.Core.Contracts;
using System;
using System.Collections.Generic;

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
