using MediaCatalog.Domain;
using MediaCatalog.Helpers;
using MediaCatalog.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Helpers;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediaCatalog.DataAccess;
using System.Threading.Tasks;

namespace MediaCatalog.Controllers
{
    [RoutePrefix("api/product")]
    [HostAuthentication("OAuth2Bearer")]
    [Authorize]
    public class ProductController : ApiController
    {
        private readonly LibraryContext _context;
        private const int PAGE_SIZE = 20;

        public ProductController()
        {
            _context = LibraryContext.Create();
        }

        public object Get([FromUri]ProductSearchModel pager = null)
        {
            if (pager == null) pager = new ProductSearchModel();

            var query = _context.Products;
            var totalCount = query.Count();

            var pred = PredicateBuilder.True<Product>();
            if (!string.IsNullOrWhiteSpace(pager.Title)) pred = pred.And(p => p.Title.Contains(pager.Title));
            if (!string.IsNullOrWhiteSpace(pager.Author)) pred = pred.And(p => p.Author.Contains(pager.Author));
            if (!string.IsNullOrWhiteSpace(pager.LCCN)) pred = pred.And(p => p.LCCN.Contains(pager.LCCN));
            if (!string.IsNullOrWhiteSpace(pager.ISBN)) pred = pred.And(p => p.ISBN.Contains(pager.ISBN));
            if (!string.IsNullOrWhiteSpace(pager.Publisher)) pred = pred.And(p => p.Publisher.Name.Contains(pager.Publisher));

            var filteredQuery = query.Where(pred);
            var pagerCount = filteredQuery.Count();

            var results = filteredQuery.Include("Publisher")
                            .Order(pager.OrderBy, pager.OrderDirection == "desc" ? SortDirection.Descending : SortDirection.Ascending)
                            .Skip(pager.PageSize * (pager.Page - 1) ?? 0)
                            .Take(pager.PageSize ?? PAGE_SIZE)
                            .ProjectTo<ProductModel>().ToList();

            var totalPages = Math.Ceiling((double)pagerCount / pager.PageSize ?? PAGE_SIZE);

            pager.TotalCount = totalCount;
            pager.FilteredCount = pagerCount;
            pager.TotalPages = totalPages;
            pager.Results = results;

            return Ok(pager);

        }

        public object Get(int id)
        {
            var product = _context.Products.Include("Staff")
                                           .Include("Publisher")
                                           .ProjectTo<ProductSummaryModel>().FirstOrDefault(p => p.Id == id);
            return product;
        }

        public object Post(CreateEditProductModel model)
        {
            var product = Mapper.Map<Product>(model);

            _context.Products.Add(product);
            _context.SaveChanges();

            var media = Mapper.Map<ProductSummaryModel>(product);

            return Ok(media);
        }

        public async Task<object> Put(CreateEditProductModel model)
        {
            var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == model.Id);
            if(product == null) return BadRequest();

            Mapper.Map(model, product);

            //if (media != null)
            //{
            //    media.Title = model.Title;
            //    media.ISBN = model.ISBN;
            //    media.Summary = model.Summary;
            //    media.PublisherId = model.PublisherId;
            //    media.Author = model.Author;
            //    media.LibraryCongressId = model.LibraryCongressId;
            //    media.ReceiptDate = model.ReceiptDate;
            //    media.Donated = model.Donated;
            //    media.Reviewed = model.Reviewed;
            //    media.Purchased = model.Purchased;
            //}
            _context.Products.AddOrUpdate(product);
            await _context.SaveChangesAsync();

            product = _context.Products.Include("Publisher").FirstOrDefault(m => m.Id == model.Id);

            //var product = new ProductModel()
            //{
            //    Id = media.Id,
            //    Title = media.Title,
            //    ISBN = media.ISBN,
            //    Publisher = media.Publisher.Name,
            //    Author = media.Author,
            //    LibraryCongressId = media.LibraryCongressId,
            //    ReceiptDate = media.ReceiptDate,
            //    Donated = media.Donated,
            //    Reviewed = media.Reviewed,
            //    Purchased = media.Purchased
            //};
            var summary = Mapper.Map<ProductSummaryModel>(product);
            return Ok(summary);
        }

        public object Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok("Deleted product successfully");
        }

        [HttpDelete, Route("staff/{id}")]
        public object DeleteStaff(int id)
        {
            var staff = _context.Staff.Find(id);
            if (staff == null) return NotFound();

            _context.Staff.Remove(staff);
            _context.SaveChanges();
            return Ok("Deleted staff");
        }

    }
}
