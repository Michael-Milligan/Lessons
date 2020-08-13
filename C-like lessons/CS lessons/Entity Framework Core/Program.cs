using Entity_Framework_Core;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;

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

        public static string[] Products =
        {
            "Banana",
            "Apple",
            "Pineapple",
            "Strawberry",
            "Lemon",
            "Orange"
        };

        static void Main(string[] args)
        {
            var Context = new BusinessContext();
            Context.GetService<ILoggerFactory>().AddProvider(new LoggerProvider());
            Context.SaveChanges();

        }

        #region RandomFunctions
        /// <summary>
        /// Fills the Customers table with the random data
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
                    FirstName = FirstNames[random.Next(0, 600000) % 6],
                    SecondName = LastNames[random.Next(0, 600000) % 6],
                    Age = random.Next(16, 32),
                    Phone = $"8999{random.Next(1000000, 9999999)}"
                };
                Customer.Email = $"{Customer.FirstName[0]}{Customer.SecondName}@hey.us";

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
        public static void AddRandomOrder(Customer[] CustomersBD)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            var Context = new BusinessContext();

            Order Order = new Order()
            {
                CustomerId = CustomersBD[random.Next(0, CustomersBD.Length)].Id,
                DateOfOrder = new DateTime(random.Next(2000, 2021), random.Next(1, 13), random.Next(1, 29)),
                Quantity = random.Next(1, 1000),
                ProductId = random.Next(1, Context.Products.Count())
            };
            Order.Value = Order.Quantity * Context.Products.Find(Order.ProductId).Price;
            Context.Orders.Add(Order);
            Context.SaveChanges();
        }

        /// <summary>
        /// Fills the Orders table with random data in different threads
        /// </summary>
        public static void FillOrders(int NumberOfOrders, Customer[] CustomersBD)
        {
            for (int i = 0; i < NumberOfOrders; ++i)
            {
                new Thread(() => AddRandomOrder(CustomersBD)).Start();
            }
        }

        /// <summary>
        /// Fills the Products table with the given identifiers checking whether they are unique in table
        /// </summary>
        /// <param name="Context"></param>
        /// <param name="ProductsNames"></param>
        public static void FillProducts(ref BusinessContext Context, string[] ProductsNames)
        {
            Product Product;
            Random random = new Random((int)DateTime.Now.Ticks);

            ProductsNames = ProductsNames.OrderBy(item => item).ToArray();
            var DBProductsNames = Context.Products.Select(item => item.ProductName).ToArray();

            for (int i = 0; i < ProductsNames.Length; ++i)
            {
                if (!DBProductsNames.Contains(ProductsNames[i]))
                {
                    Product = new Product()
                    {
                        ProductName = ProductsNames[i],
                        Price = (float)random.NextDouble() * 5
                    };
                    Context.Products.Add(Product);
                }
            }
            Context.SaveChanges();
        }

        /// <summary>
        /// Without changing the order of the Orders table changes only dates so they naturally increase
        /// </summary>
        /// <param name="Context"></param>
        public static void OrderDates(ref BusinessContext Context)
        {
            var Dates = Context.Orders.Select(item => item.DateOfOrder).OrderBy(item => item).ToArray();
            int i = 0;
            int c = Context.Orders.Count();
            foreach (var order in Context.Orders)
            {
                order.DateOfOrder = Dates[i++];
            }
            Context.SaveChanges();
        }

        /// <summary>
        /// Renews the prices with new random values
        /// </summary>
        public static void RenewPrices()
        {
            Thread.Sleep(3);
            var random = new Random();
            var Context = new BusinessContext();
            var OldPrices = new ProductsPrice()
            {
                Date = DateTime.Now,
                Apple = Context.Products.Find(1).Price,
                Banana = Context.Products.Find(2).Price,
                Lemon = Context.Products.Find(3).Price,
                Orange = Context.Products.Find(4).Price,
                Pineapple = Context.Products.Find(5).Price,
                Strawberry = Context.Products.Find(6).Price
            };
            Context.ProductsPrices.Add(OldPrices);

            foreach (var product in Context.Products)
            {
                product.Price = random.NextDouble() * 3 + 2;
            }
            Context.SaveChanges();
        }
        #endregion

        #region OneByOneFunction
        public static void AddCustomer(ref BusinessContext Context, string firstName, string secondName, int age, string email, string phone)
        {
            if (string.IsNullOrEmpty(firstName) || 
                string.IsNullOrEmpty(secondName) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(phone)) throw new ArgumentNullException();
            Regex Query = new Regex(@"(\d)\(?(\d{3})\)?\s?(\d{3})[\s-]?(\d{2})[\s-]?(\d{2})");
            var Match = Query.Match(phone);
            if (Match == null) throw new ArgumentException();
            Context.Add(new Customer()
            {
                FirstName = firstName,
                SecondName = secondName,
                Age = age,
                Email = email,
                Phone = $"{Match.Groups[0]}({Match.Groups[1]}) {Match.Groups[2]}-{Match.Groups[3]}-{Match.Groups[4]}"
            });

            Context.SaveChanges();
        }
        public static void AddOrder(ref BusinessContext Context, Customer customer, DateTime dateOfOrder, int quantity, Product product)
        {
            if (customer == null || dateOfOrder == null || quantity == 0 || product == null) throw new ArgumentNullException();
            Context.Orders.Add(new Order()
            {
                Customer = customer,
                DateOfOrder = dateOfOrder,
                Quantity = quantity,
                ProductId = product.Id,
                Value = quantity * product.Price
            }) ;

            Context.SaveChanges();
        }
        public static void AddProduct(ref BusinessContext Context, string productName, float price)
        {
            if (string.IsNullOrEmpty(productName) ||
                price == 0) throw new ArgumentNullException();
            if (Context.Products.Select(item => item.ProductName.ToLower()).Contains(productName.ToLower())) throw new ArgumentException();
            Context.Products.Add(new Product()
            {
                ProductName = productName,
                Price = price
            });
        }
        #endregion

        
    }
}
