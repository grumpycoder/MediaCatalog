using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using MediaCatalog.DataAccess;
using MediaCatalog.Domain;
using MediaCatalog.Models;

namespace MediaCatalog.Controllers
{
    [RoutePrefix("api/staff")]
    [HostAuthentication("OAuth2Bearer")]
    [Authorize]
    public class StaffController : ApiController
    {
        private readonly LibraryContext _context;

        public StaffController()
        {
            _context = LibraryContext.Create();
        }

        public object Get()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<object> Post([FromBody] StaffModel model)
        {
            var staff = await _context.Staff.FindAsync(model.Id);
            if (staff == null) return NotFound();

            var m = Mapper.Map(model, staff);
            _context.Staff.AddOrUpdate(m);

            _context.Staff.AddOrUpdate(staff);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpPost, Route("{productId}")]
        public async Task<object> Post(int productId, [FromBody] StaffModel model)
        {
            var product = await _context.Products.Include("Staff").FirstOrDefaultAsync(e => e.Id == productId);
            if (product == null) return NotFound();

            var staff = Mapper.Map<Staff>(model);
            _context.Staff.AddOrUpdate(staff);
            await _context.SaveChangesAsync();

            product.Staff.Add(staff);
            await _context.SaveChangesAsync();

            model = Mapper.Map<StaffModel>(staff);
            return Ok(model);
        }

        [HttpDelete, Route("{staffId}")]
        public async Task<object> Delete(int staffId)
        {
            var staff = await _context.Staff.FindAsync(staffId);
            if (staff == null) return NotFound();

            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
            return Ok("Delete staff member");
        }
    }
}
