using System;
using System.Collections.Generic;

namespace MediaCatalog.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string LibraryCongressId { get; set; }

        public string Summary { get; set; }
        public int PublisherId { get; set; }

        public DateTime? ReceiptDate { get; set; }
        public bool? Reviewed { get; set; }
        public bool? Purchased { get; set; }
        public bool? Donated { get; set; }


        public Publisher Publisher { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }

    }
}
