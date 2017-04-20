using System;
using System.Collections.Generic;

namespace MediaCatalog.Domain
{
    public class Publisher : IAuditable
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }

        public string Name { get; set; }
        public string WebsiteUrl { get; set; }
        public string Email { get; set; }

        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
