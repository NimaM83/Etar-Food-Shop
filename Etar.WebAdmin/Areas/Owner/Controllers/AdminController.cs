using Etar.Application.Interfaces.Services.Owner;
using Microsoft.AspNetCore.Mvc;

namespace Etar.WebAdmin.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class AdminController : Controller
    {
        private readonly IOwnerServices _services;
        public AdminController(IOwnerServices services)
        {
            _services = services;            
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Admins ()
        {
            return View(_services.AdminService.GetAdminsService.Execute());
        }
    }
}
