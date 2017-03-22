using MediaCatalog.DataAccess;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MediaCatalog
{
    public class ApplicationRoleStore : RoleStore<IdentityRole>
    {
        public ApplicationRoleStore(LibraryContext context) : base(context)
        {
        }
    }
}