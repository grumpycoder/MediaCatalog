using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using MediaCatalog.DataAccess;
using MediaCatalog.Domain;
using MediaCatalog.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;

namespace MediaCatalog.Controllers
{
    [HostAuthentication("OAuth2Bearer")]
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

        public async Task<object> Get(int id)
        {
            try
            {
                var publisher = await _context.Publishers.FirstOrDefaultAsync(p => p.Id == id);
                if (publisher == null) return BadRequest("Publisher Not Found");

                return Ok(publisher);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public async Task<object> Post(CreateEditPublisherModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var publisher = Mapper.Map<Publisher>(model);
                _context.Publishers.Add(publisher);
                await _context.SaveChangesAsync();

                return Ok(publisher);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        ModelState.AddModelError("", ve.ErrorMessage);
                    }
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.InnerException?.Message);
                return BadRequest(ModelState);
            }
        }

        public async Task<object> Put(CreateEditPublisherModel model)
        {
            var publisher = await _context.Publishers.FindAsync(model.Id);
            if (publisher == null) return BadRequest("Publisher not found");

            Mapper.Map(model, publisher);

            _context.Publishers.AddOrUpdate(publisher);
            await _context.SaveChangesAsync();

            return Ok(publisher);
        }
    }
}
