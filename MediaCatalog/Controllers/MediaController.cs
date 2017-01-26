using MediaCatalog.DataAccess;
using MediaCatalog.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MediaCatalog.Controllers
{
    public class MediaController : ApiController
    {
        private MediaContext _context;

        public MediaController()
        {
            _context = MediaContext.Create();
        }

        public IEnumerable<Media> Get()
        {
            return _context.Media.Include("Company").OrderBy(m => m.Title).Skip(0).Take(25).ToList();
        }
    }
}
