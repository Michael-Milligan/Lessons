namespace Entity_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(20)]
        public string Secondname { get; set; }

        public int? Age { get; set; }

        [StringLength(20)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> orders { get; set; }
    }
}
