using Etar.Application.Interfaces.Services.Admin;
using Etar.Application.Services.Admins.User.Commands.AddNewAdmin;
using Etar.Domain.Entities;
using Etar.Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace Etar.WebAdmin.Controllers
{
    public class UserController : Controller
    {
        private readonly IAdminServices _service;

        public UserController(IAdminServices service)
        {
            _service = service; 
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(ReqAddNewAdminDto admin)
        {
            return Json(_service.UserServices.addNewAdminService.Execute(admin));
        }
    }
}
