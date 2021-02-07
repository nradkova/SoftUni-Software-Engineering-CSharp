using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Robot : Inhabitant
    {
        public Robot(string model,string id)
        {
            Model = model;
            Id = id;
        }
        public string  Model { get;}
        public override string Id { get; }
    }
}
