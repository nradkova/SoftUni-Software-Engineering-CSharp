using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Models
{
  public interface   IBorn
    {
        public  string BirthDate { get; }
        public void  PrintBirthDate();
    }
}
