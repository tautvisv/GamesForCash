using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using UnitOfWorkExample.Domain.Entities;
using UnitOfWorkExample.Domain.Services;
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
            return View(new LoginModel());
        }

        [HttpPost]
        public string Login(LoginModel model)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return "Authenti";
            }
            return "Unauthorized";
        }

        [HttpGet]
        [Authorize]
        public ActionResult Logout()
        {
            return null;
        }

        [HttpPost]
        public ActionResult Register(string username, string password)
        {
            return null;
        }
    }
}