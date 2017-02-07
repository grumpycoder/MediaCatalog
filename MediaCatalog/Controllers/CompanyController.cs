using MediaCatalog.DataAccess;
using MediaCatalog.Domain;
using System.Collections.Generic;
using System.Web.Http;

namespace MediaCatalog.Controllers
{
    public class CompanyController : ApiController
    {
        private LibraryContext _context;

        public CompanyController()
        {
            _context = LibraryContext.Create();
        }

        //public IEnumerable<Publisher> Get()
        //{
        //    //return _context.Companies.Include("Staff");
        //}
    }
}
