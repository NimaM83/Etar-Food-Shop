using Etar.Application.Interfaces.Services.Admin;
using Etar.Application.Services.Admins.Food.Commands.AddFood;
using Etar.Application.Services.Admins.Food.Commands.UpdateFood;
using Etar.Application.Services.Admins.Food.Queries.GetFoods;
using Etar.Domain.Entities;
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

        public IActionResult Index(Guid? catId)
        {
            ViewBag.Categories = _service.FoodServices.GetCategoriesService.Execute(null).Data.Categories;
            return View(_service.FoodServices.GetFoodsService.Execute(catId));
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

        public IActionResult Remove(Guid id)
        {
            return Json(_service.FoodServices.RemoveFoodService.Execute(id));
        }

        public IActionResult Details(Guid id)
        {
            return View(_service.FoodServices.GetFoodDetaisService.Execute(id));
        }

        [HttpGet]
        public IActionResult Update (Guid id)
        {
            ViewBag.Categories = _service.FoodServices.GetCategoriesService.Execute(null).Data.Categories;

            ResGetFoodDto retrivedFood = _service.FoodServices.GetFoodsService.Execute(id).Data;
            ReqUpdateFoodDto sendFood = new ReqUpdateFoodDto()
            {
                Name = retrivedFood.Name,
                Id = retrivedFood.Id,
                CategoryId = retrivedFood.CategoryId,
                Description = retrivedFood.Description,
                Price = retrivedFood.Price,
            };

            return View(sendFood);
        }

        [HttpPost]
        public IActionResult Update(ReqUpdateFoodDto request)
        {
            return Json(_service.FoodServices.UpdateFoodService.Execute(request));
        }

        public IActionResult Inventory (Guid? catId)
        {
            ViewBag.Categories = _service.FoodServices.GetCategoriesService.Execute(null).Data.Categories;
            return View(_service.FoodServices.GetFoodsService.Execute(catId));
        }

        public IActionResult UpdateInventory(Guid id, int editAmount)
        {
            Result result = _service.FoodServices.UpdateInventoryService.Execute(id, editAmount);

            if(!result.IsSuccess)
            {
                return Json(result);
            }

            return RedirectToAction("Inventory");
        }

        public IActionResult ResetById(Guid? id)
        {
            return Json(_service.FoodServices.ResetInventoryService.Execute(id));
        }

        public IActionResult ResetByCategory(Guid categoryId)
        {
            return Json(_service.FoodServices.ResetInventoryService.Execute(categoryId));
        }



    }
}
