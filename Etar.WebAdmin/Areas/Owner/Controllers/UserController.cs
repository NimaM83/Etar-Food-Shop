using Microsoft.AspNetCore.Mvc;

namespace Etar.WebAdmin.Areas.Owner.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
