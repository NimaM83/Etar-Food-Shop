using Etar.Application.Interfaces.Services.Admin;
using Etar.Application.Services.Admins.Food.Commands.AddFood;
using Microsoft.AspNetCore.Mvc;

namespace Etar.WebAdmin.Controllers
{
    public class FoodsController : Controller
    {
        private readonly IAdminServices _service;
        public FoodsController (IAdminServices adminServices)
        {
            _service = adminServices;
        }

        public IActionResult Index()
        {
            return View(_service.FoodServices.GetFoodsService.Execute());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _service.FoodServices.GetCategoriesService.Execute(null).Data.Categories;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ReqAddFoodDto newFood)
        {
            return Json(_service.FoodServices.AddFoodService.Execute(newFood));
        }

    }
}
