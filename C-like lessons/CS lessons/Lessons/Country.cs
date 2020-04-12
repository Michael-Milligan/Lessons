using System.Collections.Generic;

namespace Lessons
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tank> Tanks { get; set; } 
    }
}
