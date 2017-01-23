using System.Collections.Generic;
using MediaCatalog.DataAccess;
using System.Web.Http;
using MediaCatalog.Domain;

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
            return _context.Companies;
        }
    }
}
