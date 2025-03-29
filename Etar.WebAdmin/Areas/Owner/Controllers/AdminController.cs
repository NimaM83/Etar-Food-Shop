using Microsoft.AspNetCore.Mvc;

namespace Etar.WebAdmin.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
