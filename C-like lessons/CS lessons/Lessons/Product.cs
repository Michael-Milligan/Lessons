using System;
using System.Collections.Generic;
using System.Linq;

namespace Lessons
{
    public class Product
    {
        public string Name { get; set; }
        public int Energy { get; set; }

        public Product(string Name, int Energy)
        {
            this.Name = Name;
            this.Energy = Energy;
        }

        public override string ToString()
        {
            return "Name: " + Name + " Energy: " + Energy;
        }
    }
}
