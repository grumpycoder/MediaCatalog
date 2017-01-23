using System.Collections.Generic;

namespace MediaCatalog.Domain
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WebsiteUrl { get; set; }
        public string Email { get; set; }

        public virtual ICollection<StaffMember> Staff { get; set; }
    }
}
