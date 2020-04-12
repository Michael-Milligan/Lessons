namespace Lessons
{
    public class Tank
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }
        public double? Mass { get; set; }
        public int GunCaliber { get; set; }
        public int? Crew { get; set; }

        public virtual Country Country { get; set; }
    }
}
