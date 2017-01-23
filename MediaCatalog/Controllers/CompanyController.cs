using MediaCatalog.DataAccess;
using MediaCatalog.Domain;
using System.Collections.Generic;
using System.Web.Http;

namespace MediaCatalog.Controllers
{
    public class CompanyController : ApiController
    {
        private MediaContext _context;

        public CompanyController()
        {
            _context = MediaContext.Create();
        }

        public IEnumerable<Company> Get()
        {
            return _context.Companies.Include("Staff");
        }
    }
}
