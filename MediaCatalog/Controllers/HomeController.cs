using System.Security.Claims;
using System.Web.Mvc;
using ClaimTypes = System.IdentityModel.Claims.ClaimTypes;

namespace MediaCatalog.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = User as ClaimsPrincipal;

            ViewBag.Name = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Name).Value;
            ViewBag.ObjectId = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
            ViewBag.GivenName = ClaimsPrincipal.Current.FindFirst(ClaimTypes.GivenName).Value;
            ViewBag.Surname = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Surname).Value;
            ViewBag.UPN = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Upn).Value;

            ViewBag.UPN = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Upn).Value;

            return View(user?.Claims);
        }


    }
}