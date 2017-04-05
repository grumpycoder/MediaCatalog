using System.Security.Claims;
using System.Web.Mvc;

namespace MediaCatalog.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.GivenName = ClaimsPrincipal.Current.FindFirst(ClaimTypes.GivenName).Value;
            return View();
        }


    }
}