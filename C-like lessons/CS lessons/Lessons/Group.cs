using System;
using System.Collections.Generic;

namespace Lessons
{
    public class Group
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? BeginYear { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
