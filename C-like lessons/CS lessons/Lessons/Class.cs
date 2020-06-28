using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Lessons
{
    [DataContract]
    public class Class
    {
        [DataMember]
        public string Name { get; set; }

        public Class(string name)
        {
            //Check for invalid parameters
            Name = name;
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }

        public Class()
        {

        }
    }
}
