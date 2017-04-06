using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

namespace MediaCatalog.Controllers
{
    public class AccountController : Controller
    {
        public void SignIn()
        {
            // Send an OpenID Connect sign-in request.
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }

        public void SignOut()
        {
            string callbackUrl = Url.Action("SignOutCallback", "Account", routeValues: null, protocol: Request.Url.Scheme);

            HttpContext.GetOwinContext().Authentication.SignOut(
                new AuthenticationProperties { RedirectUri = callbackUrl },
                OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
        }

        public ActionResult SignOutCallback()
        {
            if (Request.IsAuthenticated)
            {
                //Redirect to home page if the user is authenticated.
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        //private ApplicationSignInManager _signInManager;
        //private ApplicationUserManager _userManager;

        //public AccountController()
        //{
        //}

        //public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        //{
        //    UserManager = userManager;
        //    SignInManager = signInManager;
        //}

        //public ApplicationSignInManager SignInManager
        //{
        //    get { return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
        //    private set { _signInManager = value; }
        //}

        //public ApplicationUserManager UserManager
        //{
        //    get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        //    private set { _userManager = value; }
        //}

        //private IAuthenticationManager AuthenticationManager
        //{
        //    get { return HttpContext.GetOwinContext().Authentication; }
        //}

        //[AllowAnonymous, HttpGet]
        //public ActionResult Login(string returnUrl)
        //{
        //    ViewBag.ReturnUrl = returnUrl;
        //    return View();
        //}

        ////[HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        //[HttpPost]
        //public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    var env = ConfigurationManager.AppSettings["Environment"];
        //    var user = UserManager.FindByName(model.Username);

        //    if (user != null)
        //    {
        //        switch (env)
        //        {
        //            case "Prod":
        //                if (Membership.ValidateUser(model.Username, model.Password))
        //                {
        //                    await SignInManager.SignInAsync(user, true, model.RememberMe);
        //                    return RedirectToLocal(returnUrl);
        //                }
        //                ModelState.AddModelError("", "Invalid username or password.");
        //                break;

        //            default:
        //                await SignInManager.SignInAsync(user, true, model.RememberMe);
        //                return RedirectToLocal(returnUrl);
        //        }
        //        if (ModelState.IsValid)
        //        {
        //            await SignInManager.SignInAsync(user, true, model.RememberMe);
        //            return RedirectToLocal(returnUrl);
        //        }

        //    }

        //    ModelState.AddModelError("", "You are not authorized.");

        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LogOff()
        //{
        //    AuthenticationManager.SignOut();
        //    return RedirectToAction("Index", "Home");
        //}

        //private ActionResult RedirectToLocal(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    return RedirectToAction("", "Home");
        //}
    }
}