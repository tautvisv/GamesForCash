using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWorkExample.Domain.Entities;
using UnitOfWorkExample.Domain.Services;

namespace UnitOfWorkExample.Web.Controllers
{
    public class AccountController : BaseController
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Account
        public string Index()
        {
            // ensure there are products for the example
            var users = _userService.GetAll();
            if (!users.Any())
            {
                _userService.Create(new User { Name = "User 1" });
                _userService.Create(new User { Name = "User 2" });
                _userService.Create(new User { Name = "User 3" });
            }
            return users.Count.ToString();
        }
        // GET: Account
        public ActionResult Login()
        {
            return null;
        }
        // GET: Account
        public ActionResult Logout()
        {
            return null;
        }
        // GET: Account
        public ActionResult Register()
        {
            return null;
        }
    }
}