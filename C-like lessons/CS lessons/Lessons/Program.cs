using System;
using System.Collections.Generic;

namespace Lessons
{
    public class Program
    {
        public static void Main()
        {
            using (var Context = new DBContext())
            {
                #region Countries
                Country USA = new Country()
                {
                    Name = "USA"
                };
                Country Germany = new Country()
                {
                    Name = "Germany"
                };
                List<Country> Countries = new List<Country>();
                Countries.Add(USA);
                Countries.Add(Germany);
                Context.Country.AddRange(Countries);

                #endregion

                Tank M4A2 = new Tank()
                {
                    Name = "M4A2",
                    CountryID = 1,
                    GunCaliber = 75
                };

                Context.Tank.Add(M4A2);

                Context.SaveChanges();
            }
        }
    }
}
