using MediaCatalog.DataAccess;
using MediaCatalog.Domain;
using MediaCatalog.Models;
using System.Linq;
using System.Web.Http;

namespace MediaCatalog.Controllers
{
    [Authorize]
    public class PublisherController : ApiController
    {
        private readonly LibraryContext _context;

        public PublisherController()
        {
            _context = LibraryContext.Create();
        }

        public object Get()
        {
            return _context.Publishers.ToList();
        }

        public object Get(int id)
        {
            return _context.Publishers.FirstOrDefault(p => p.Id == id);
        }

        public object Post(CreateEditPublisherModel model)
        {
            var publisher = new Publisher()
            {
                Name = model.Name,
                WebsiteUrl = model.WebsiteUrl,
                Email = model.Email,
                Street = model.Street,
                Street2 = model.Street2,
                City = model.City,
                State = model.State,
                Zipcode = model.Zipcode,
                Phone = model.Phone
            };

            _context.Publishers.Add(publisher);
            _context.SaveChanges();

            return Ok(publisher);
        }

    }
}
