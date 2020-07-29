using System;
using System.Collections.Generic;

namespace Entity_Framework_Core
{
    public partial class Orders
    {
        public int Id { get; set; }
        public int Customerid { get; set; }
        public DateTime Dateoforder { get; set; }
        public int? Quantity { get; set; }
        public int? Productid { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
