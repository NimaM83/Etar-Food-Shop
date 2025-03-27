using Etar.Application.Interfaces.Services.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Etar.WebAdmin.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAdminServices _services;
        public OrderController (IAdminServices services)
        {
            _services = services;
        }
        public IActionResult Index(Guid? catId)
        {
            ViewBag.Categories = _services.FoodServices.GetCategoriesService.Execute(null).Data.Categories;
            return View(_services.FoodServices.GetFoodsService.Execute(catId));
        }
    }
}
