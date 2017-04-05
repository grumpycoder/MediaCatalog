using System;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;

namespace MediaCatalog.Controllers
{
    public class AuthController : ApiController
    {

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost, AllowAnonymous, ActionName("Authenticate")]
        public object Authenticate(string user, string password)
        {

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
                return "failed";
            var userIdentity = UserManager.FindAsync(user, password).Result;
            if (userIdentity == null) return "failed";

            var identity = new ClaimsIdentity(Startup.OAuthBearerOptions.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userIdentity.Id));
            var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
            var currentUtc = new SystemClock().UtcNow;
            ticket.Properties.IssuedUtc = currentUtc;
            ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));

            var accessToken = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);

            return accessToken;

        }

    }
}
