using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UnitOfWorkExample.Domain.Entities;
using UnitOfWorkExample.Domain.Services;
using UnitOfWorkExample.Web.Helpers.Security;
using UnitOfWorkExample.Web.Models.Account;

namespace UnitOfWorkExample.Web.Controllers
{
    public class AccountController : BaseController
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            if (model == null)
                return Redirect("/account/");

            var user = _userService.GetByUsername(model.Username);
            if (user == null)
                return Redirect("/account/");
            if (user.Password == model.Password)
            {
                var authTicket = FormsAuthentication.Encrypt(
                    new FormsAuthenticationTicket(
                        1,
                        user.Name,
                        DateTime.Now, DateTime.Now.AddDays(1).ToUniversalTime(),
                        true,
                        user.Roles)
                    );
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, authTicket);
                ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }
            return Redirect("/");
        }

        [HttpGet]
        [CustomAuthorization]
        public ActionResult Logout()
        {
            return null;
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string username, string password)
        {
            return null;
        }
    }
}