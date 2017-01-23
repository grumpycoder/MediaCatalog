using MediaCatalog.Domain;
using System.Data.Entity;

namespace MediaCatalog.DataAccess
{
    public class MediaContext : DbContext
    {

        public MediaContext() : base("name=MediaContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static MediaContext Create()
        {
            return new MediaContext();
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<StaffMember> StaffMembers { get; set; }
    }
}
