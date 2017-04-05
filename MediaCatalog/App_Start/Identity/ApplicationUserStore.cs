using MediaCatalog.DataAccess;
using MediaCatalog.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MediaCatalog
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(LibraryContext context) : base(context)
        {
        }
    }
}