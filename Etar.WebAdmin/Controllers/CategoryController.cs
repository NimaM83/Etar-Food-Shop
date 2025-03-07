using Etar.Application.Interfaces.Services.Admin;
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
    }
}
