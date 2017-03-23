using System;
using System.Collections.Generic;
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
    [RoutePrefix("api/staff"), Authorize]
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
        public object Post([FromBody] StaffModel model)
        {
            var staff = _context.Staff.Find(model.Id);
            if (staff == null) return NotFound();

            var m = Mapper.Map(model, staff);
            _context.Staff.AddOrUpdate(m);

            _context.Staff.AddOrUpdate(staff);
            _context.SaveChanges();
            return Ok(model);
        }

        [HttpPost, Route("{productId}")]
        public object Post(int productId, [FromBody] StaffModel model)
        {
            var product = _context.Products.Include("Staff").FirstOrDefault(e => e.Id == productId);
            if (product == null) return NotFound();

            var staff = new Staff()
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Email = model.Email,
                Role = model.Role
            };

            _context.Staff.AddOrUpdate(staff);
            _context.SaveChanges();
            product.Staff.Add(staff);
            _context.SaveChanges();

            model = Mapper.Map<StaffModel>(staff);
            return Ok(model);
        }

        [HttpDelete, Route("{staffId}")]
        public object Delete(int staffId)
        {
            var staff = _context.Staff.Find(staffId);
            if (staff == null) return NotFound();

            _context.Staff.Remove(staff);
            _context.SaveChanges();
            return Ok("Delete staff member");
        }
    }
}
