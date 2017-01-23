using MediaCatalog.Domain;
using System.Data.Entity;

namespace MediaCatalog.DataAccess
{
    public class MediaContext : DbContext
    {

        public MediaContext() : base("name=MediaContext")
        {

        }

        public static MediaContext Create()
        {
            return new MediaContext();
        }

        public DbSet<Company> Companies { get; set; }
    }
}
