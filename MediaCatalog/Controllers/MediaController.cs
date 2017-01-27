using MediaCatalog.DataAccess;
using MediaCatalog.Models;
using System;
using System.Linq;
using System.Web.Http;
using MediaCatalog.Domain;
using MediaCatalog.Helpers;

namespace MediaCatalog.Controllers
{
    [RoutePrefix("api/media")]
    public class MediaController : ApiController
    {
        private readonly MediaContext _context;
        private const int PAGE_SIZE = 20;

        public MediaController()
        {
            _context = MediaContext.Create();
        }

        public object Get([FromUri]MediaSearchModel pager = null)
        {
            if (pager == null) pager = new MediaSearchModel();

            var query = _context.Media;

            var baseQuery = query.Include("Company").OrderBy(m => m.Title);

            var totalCount = baseQuery.Count();
            var totalPages = Math.Ceiling((double)totalCount / PAGE_SIZE);

            var pred = PredicateBuilder.True<Media>();
            if (!string.IsNullOrWhiteSpace(pager.Title)) pred = pred.And(p => p.Title.Contains(pager.Title));
            if (!string.IsNullOrWhiteSpace(pager.ISBN)) pred = pred.And(p => p.ISBN.Contains(pager.ISBN));
            if (!string.IsNullOrWhiteSpace(pager.Company)) pred = pred.And(p => p.Company.Name.Contains(pager.Company));

            var results = baseQuery.Skip(pager.PageSize * pager.Page ?? 0)
                       .Where(pred)
                       .Take(pager.PageSize ?? PAGE_SIZE)
                       .ToList()
                       .Select(m => new MediaModel()
                       {
                           Id = m.Id,
                           Title = m.Title,
                           ISBN = m.ISBN,
                           Company = m.Company.Name
                       });

            pager.TotalCount = totalCount;
            pager.TotalPages = totalPages;
            pager.Results = results;

            return pager;

        }

    }
}
