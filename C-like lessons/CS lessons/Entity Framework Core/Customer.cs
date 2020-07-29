using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Entity_Framework_Core
{
    public partial class Customer : IEquatable<Customer>
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Equals([AllowNull] Customer other)
        {
            return Email == other.Email;
        }
    }
}
