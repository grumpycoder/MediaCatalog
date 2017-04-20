using System;
using System.Collections.Generic;

namespace MediaCatalog.Domain
{
    public class Product : IAuditable
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }

        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string LCCN { get; set; }

        public string Summary { get; set; }
        public int PublisherId { get; set; }

        public DateTime? ReceiptDate { get; set; }
        public bool Reviewed { get; set; } = false;
        public bool Purchased { get; set; } = false;
        public bool Donated { get; set; } = false;


        public Publisher Publisher { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }

    }
}
