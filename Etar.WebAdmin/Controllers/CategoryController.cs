using Etar.Application.Interfaces.Services.Admin;
using Etar.Application.Services.Admins.Food.Commands.UpdateCategory;
using Etar.Domain.Entities.Foods;
using Microsoft.AspNetCore.Mvc;

namespace Etar.WebAdmin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IAdminServices _service;
        public CategoryController(IAdminServices service)
        { 
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.FoodServices.GetCategoriesService.Execute(null));
        }

        [HttpGet]
        public IActionResult Create ()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(FoodCategory category)
        {
            return Json(_service.FoodServices.AddNewCategoryService.Execute(category.Name));
        }

        public IActionResult Remove(Guid id)
        {
            return Json(_service.FoodServices.RemoveCategoryService.Execute(id));
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            FoodCategory category = _service.FoodServices.GetCategoriesService.Execute(id).Data
                                    .Categories.FirstOrDefault() ?? new FoodCategory();
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(FoodCategory category)
        {
            return Json(_service.FoodServices.UpdateCategoryService.Execute(new ReqUpdateCategoryDto()
                                                                            {
                                                                                Id = category.Id,
                                                                                Name = category.Name,
                                                                            }));
        }


    }
}
