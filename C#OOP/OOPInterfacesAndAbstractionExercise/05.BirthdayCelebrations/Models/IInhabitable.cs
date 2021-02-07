using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Models
{
   public interface IInhabitable
    {
        public  string  Id { get;}

        public void PrintId();
    }
}
