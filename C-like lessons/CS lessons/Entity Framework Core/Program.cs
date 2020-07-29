using System;
using System.Linq;

namespace Entity_Framework
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
                FillOrders(ref Context);
                
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

        public static void FillOrders(ref BusinessContext Context)
        {
            Order[] Orders = new Order[100];
            Random random = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < Orders.Length; ++i)
            {
                Orders[i] = new Order()
                {
                    Customerid = Context.Customers.ElementAt(random.Next(1,5)).Id,
                    Dateoforder = new DateTime(random.Next(1800, 2021), random.Next(1, 13), random.Next(1,29)),
                    Quantity = random.Next(1, 1000)
                };
                
                Context.Orders.Add(Orders[i]);
            }

            Context.SaveChanges(); 
        }
    }
}
