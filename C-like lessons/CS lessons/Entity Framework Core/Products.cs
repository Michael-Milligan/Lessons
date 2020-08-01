using System;
using System.Collections.Generic;

namespace Entity_Framework_Core
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
