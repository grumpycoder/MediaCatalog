using System.Data.Entity;

namespace MediaCatalog.DataAccess
{
    public class MediaContext : DbContext
    {

        public MediaContext() : base("name=MediaContext")
        {

        }
    }
}
