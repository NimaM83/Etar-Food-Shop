using Etar.Application.Interfaces.Context;
using Etar.Application.Interfaces.Services.Admin;
using Etar.Common.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Etar.WebAdmin.Controllers
{
    public class CartController : Controller
    {
        private readonly IAdminServices _services;
        private readonly CookiesManager _cookies;
        public CartController (IAdminServices services)
        {
            _services = services;
            _cookies = new CookiesManager ();
        }

        public IActionResult Index()
        {
            Guid adminId = Guid.Parse(_cookies.GetValue(HttpContext, "Id"));
            return View(_services.CartServices.GetCartService.Execute(adminId));
        }

        public IActionResult AddItem (Guid foodId)
        {
            Guid adminId = Guid.Parse(_cookies.GetValue(HttpContext, "Id"));
            return Json(_services.CartServices.AddItemService.Execute(foodId,adminId));
        }

        public IActionResult RemoveItem (Guid foodId, bool isDecrease = false)
        {
            Guid adminId = Guid.Parse(_cookies.GetValue(HttpContext, "Id"));
            return Json(_services.CartServices.RemoveItemService.Execute(foodId,adminId));
        }

        public IActionResult Confirm (Guid cartId)
        {
            return Json(_services.CartServices.ConfirmCartService.Execute(cartId));
        }
    }
}
