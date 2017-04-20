using System;
using System.Collections.Generic;

namespace MediaCatalog.Domain
{
    public class Staff : IAuditable
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string Email { get; set; }
        public string Role { get; set; }

        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
