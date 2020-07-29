namespace Entity_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int Id { get; set; }

        public int Customerid { get; set; }

        public DateTime Dateoforder { get; set; }

        public int? Quantity { get; set; }

        public int? Productid { get; set; }

        public virtual Customer customers { get; set; }
    }
}
