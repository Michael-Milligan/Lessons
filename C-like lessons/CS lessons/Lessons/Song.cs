using System;

namespace Lessons
{
    public class Song
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int GroupID { get; set; }

        public virtual Group Group { get; set; }
    }
}
