using MediaCatalog.DataAccess;
using MediaCatalog.Domain;
using MediaCatalog.Helpers;
using MediaCatalog.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Http;

namespace MediaCatalog.Controllers
{
    [RoutePrefix("api/product")]
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

            var baseQuery = query.Include("Publisher").OrderBy(m => m.Title);

            var totalCount = baseQuery.Count();
            var totalPages = Math.Ceiling((double)totalCount / PAGE_SIZE);

            var pred = PredicateBuilder.True<Product>();
            if (!string.IsNullOrWhiteSpace(pager.Title)) pred = pred.And(p => p.Title.Contains(pager.Title));
            if (!string.IsNullOrWhiteSpace(pager.ISBN)) pred = pred.And(p => p.ISBN.Contains(pager.ISBN));
            if (!string.IsNullOrWhiteSpace(pager.Publisher)) pred = pred.And(p => p.Publisher.Name.Contains(pager.Publisher));

            var results = baseQuery.Skip(pager.PageSize * pager.Page ?? 0)
                       .Where(pred)
                       .Take(pager.PageSize ?? PAGE_SIZE)
                       .ToList()
                       .Select(m => new ProductModel
                       {
                           Id = m.Id,
                           Title = m.Title,
                           ISBN = m.ISBN,
                           Company = m.Publisher.Name
                       });

            pager.TotalCount = totalCount;
            pager.TotalPages = totalPages;
            pager.Results = results;

            return pager;

        }

        public object Get(int id)
        {
            var product = _context.Products.Include("Staff").FirstOrDefault(p => p.Id == id);
            return product;
        }

        public object Post(CreateEditProductModel model)
        {

            var product = new Product()
            {
                Title = model.Title,
                ISBN = model.ISBN,
                Summary = model.Summary,
                PublisherId = model.PublisherId
            };
            _context.Products.Add(product);
            _context.SaveChanges();

            var media = _context.Products.Select(m => new ProductModel
            {
                Id = m.Id,
                Title = m.Title,
                ISBN = m.ISBN,
                Company = m.Publisher.Name
            }).FirstOrDefault(x => x.Id == product.Id);

            return Ok(media);
        }

        public object Put(CreateEditProductModel model)
        {
            var media = _context.Products.FirstOrDefault(m => m.Id == model.Id);

            if (media != null)
            {
                media.Title = model.Title;
                media.ISBN = model.ISBN;
                media.Summary = model.Summary;
                media.PublisherId = model.PublisherId;
            }
            _context.Products.AddOrUpdate(media);
            _context.SaveChanges();

            media = _context.Products.Include("Publisher").FirstOrDefault(m => m.Id == model.Id);

            var product = new ProductModel()
            {
                Id = media.Id,
                Title = media.Title,
                ISBN = media.ISBN,
                Company = media.Publisher.Name
            };
            return product;
        }

        //[HttpPost, Route("Staff")]
        //public object Staff(StaffMember staff)
        //{

        //    return Ok();
        //}

    }
}
