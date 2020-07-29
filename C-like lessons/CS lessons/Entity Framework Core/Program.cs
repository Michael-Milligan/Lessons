using System;
using System.Linq;
using Entity_Framework_Core;

namespace Entity_Framework_Core
{
    class Program
    {
        public static string[] FirstNames =
        {
            "Oliver",
            "Travis",
            "Hailey",
            "Clark",
            "Leo",
            "Edwin"
        };

        public static string[] LastNames =
        {
            "Clark",
            "Phillips",
            "Sanchez",
            "Scott",
            "Baker",
            "Wood"
        };

        static void Main(string[] args)
        {
            var Context = new BusinessContext();

            for (int i = 0; i < 20; ++i)
            {
                try
                {
                    FillCustomers(ref Context);
                }
                catch (Exception) { }
                
            }
        }

        public static void ClearCustomers(ref BusinessContext Context)
        {
            for (int i = 0; i < 10; ++i)
            {
                Context.Customers.Remove(Context.Customers.Find(i + 10));
            }
            Context.SaveChanges();
        }

        public static void FillCustomers(ref BusinessContext Context)
        {
            Customer[] Customers = new Customer[10];
            Random random = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < Customers.Length; ++i)
            {
                Customers[i] = new Customer()
                {
                    Firstname = FirstNames[random.Next(0, 600000)%6],
                    Secondname = LastNames[random.Next(0, 600000)%6],
                    Age = random.Next(16, 32),
                    Phone = $"8999{random.Next(1000000, 9999999)}"
                };
                Customers[i].Email = $"{Customers[i].Firstname[0]}{Customers[i].Secondname}@hey.us";
                Customers = Customers.Distinct().ToArray();
                Context.Customers.Add(Customers[i]);
            }
            
            Context.SaveChanges();
        }
    }
}
