using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
   public abstract class Inhabitant
    {
        public virtual string  Id { get;}

        public override string ToString()
        {
            return Id;
        }
      
    }
}
