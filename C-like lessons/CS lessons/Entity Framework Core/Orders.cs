using System;
using System.Collections.Generic;

namespace Entity_Framework_Core
{
    public partial class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateOfOrder { get; set; }
        public int? Quantity { get; set; }
        public int? ProductId { get; set; }
        public double? Value { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
