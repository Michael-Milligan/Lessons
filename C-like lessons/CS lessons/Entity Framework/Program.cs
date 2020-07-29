using System;
using System.Linq;
using System.Threading.Tasks;

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
            var CustomersBD = Context.Customers.ToArray();
            ClearOrders(ref Context);
            for (int i = 0; i < 50000; ++i)
            {
                AddOrderAsync(CustomersBD);
            }
            
        }

        /// <summary>
        /// Clears the whole table customers
        /// </summary>
        /// <param name="Context"></param>
        public static void ClearCustomers(ref BusinessContext Context)
        {
            var CustomersBD = Context.Customers.ToArray();
            for (int i = 0; i < 10; ++i)
            {
                Context.Customers.Remove(Context.Customers.Remove(CustomersBD[i]));
            }
            Context.SaveChanges();
        }

        /// <summary>
        /// Clears the whole table orders
        /// </summary>
        /// <param name="Context"></param>
        public static void ClearOrders(ref BusinessContext Context)
        {
            var OrdersBD = Context.Orders.ToArray();
            for (int i = 0; i < OrdersBD.Length; ++i)
            {
                Context.Orders.Remove(OrdersBD[i]);
            }
            Context.SaveChanges();
        }

        /// <summary>
        /// Fills the customers table with the random data
        /// </summary>
        /// <param name="Context"></param>
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

        /// <summary>
        /// Adds one random order, but doesn't save the data
        /// </summary>
        /// <param name="Context"></param>
        public static void AddOrder(ref BusinessContext Context, Customer[] CustomersBD)
        {
            Random random = new Random((int)DateTime.Now.Ticks);

            Order Order = new Order()
            {
                Customerid = CustomersBD[random.Next(0, CustomersBD.Length)].Id,
                Dateoforder = new DateTime(random.Next(1800, 2021), random.Next(1, 13), random.Next(1,29)),
                Quantity = random.Next(1, 1000)
            };
            Context.Orders.Add(Order);
            Context.SaveChanges();
        }

        public static async void AddOrderAsync(Customer[] CustomersBD)
        {
            var Context = new BusinessContext();
            await Task.Run(() => AddOrder(ref Context, CustomersBD));
        }
    }
}
