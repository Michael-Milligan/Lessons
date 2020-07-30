using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
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

            Regex Query = new Regex(@"([ABC]\w+)@hey\.us");

            string Result = "";

            foreach (var Customer in Context.Customers)
            {
                Result += Customer.Email;
            }

            var Matches = Query.Matches(Result);
            foreach (var Match in Matches)
            {
                Console.WriteLine(Match);
            }
        }

        #region Functions
        /// <summary>
        /// Fills the customers table with the random data
        /// </summary>
        /// <param name="Context"></param>
        public static void FillCustomers(ref BusinessContext Context, int NumberOfClients)
        {
            Customer Customer;
            Random random = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < NumberOfClients;)
            {
                Customer = new Customer()
                {
                    Firstname = FirstNames[random.Next(0, 600000)%6],
                    Secondname = LastNames[random.Next(0, 600000)%6],
                    Age = random.Next(16, 32),
                    Phone = $"8999{random.Next(1000000, 9999999)}"
                };
                Customer.Email = $"{Customer.Firstname[0]}{Customer.Secondname}@hey.us";

                var CustomersEmails = Context.Customers.Select(item => item.Email).ToArray();
                var CustomersPhones = Context.Customers.Select(item => item.Phone).ToArray();

                if (!CustomersEmails.Contains(Customer.Email) && !(CustomersPhones.Contains(Customer.Phone)))
                {
                    ++i;
                    Context.Customers.Add(Customer);
                    Context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Adds one random order, but doesn't save the data
        /// </summary>
        /// <param name="Context"></param>
        public static void AddOrder(Customer[] CustomersBD)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            var Context = new BusinessContext();

            Order Order = new Order()
            {
                Customerid = CustomersBD[random.Next(0, CustomersBD.Length)].Id,
                Dateoforder = new DateTime(random.Next(2000, 2021), random.Next(1, 13), random.Next(1,29)),
                Quantity = random.Next(1, 1000)
            };
            Context.Orders.Add(Order);
            Context.SaveChanges();
        }

        /// <summary>
        /// Fills the orders table with random data in different threads
        /// </summary>
        public static void FillOrders(int NumberOfOrders, Customer[] CustomersBD)
        {
            for (int i = 0; i < NumberOfOrders; ++i)
            {
                new Thread(() => AddOrder(CustomersBD)).Start();
            }
        }
        #endregion
    }
}
