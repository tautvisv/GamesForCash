using System.Web.Mvc;

namespace UnitOfWorkExample.Web.Controllers.Games
{
    public class CheckersController : Controller
    {
        // GET: Checkers
        public ActionResult Index()
        {
            return View();
        }
    }
}