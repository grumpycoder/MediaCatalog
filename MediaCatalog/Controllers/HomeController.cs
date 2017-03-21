using System.Web.Mvc;

namespace MediaCatalog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


    }
}