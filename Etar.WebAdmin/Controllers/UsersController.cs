using Etar.Application.Interfaces.Services.Admin;
using Etar.Application.Services.Admins.User.Commands.AddNewAdmin;
using Etar.Domain.Entities;
using Etar.Domain.Entities.Foods;
using Etar.Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace Etar.WebAdmin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAdminServices _service;

        public UsersController(IAdminServices service)
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

        public IActionResult Admins ()
        {
            var res = _service.UserServices.getAdminsService.Execute();

            return View(res);
        }

        public IActionResult  Remove (Guid Id)
        {
           
            return Json(_service.UserServices.removeAdminService.Execute(Id));
        }
    }
}
