using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns.Contracts
{
    public interface IGun
    {
        string Name { get; }

        int BulletsCount { get; }

        int Fire();
    }
}
