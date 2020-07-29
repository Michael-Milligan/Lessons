using System;
using System.Collections.Generic;

namespace Entity_Framework_Core
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
