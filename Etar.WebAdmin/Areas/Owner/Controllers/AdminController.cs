using Etar.Application.Interfaces.Services.Owner;
using Etar.Application.Services.Owners.Admin.Commands.AddNewAdmin;
using Etar.Application.Services.Owners.Admin.Commands.EditAdmin;
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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(ReqAddNewAdminDto request)
        {
            return Json(_services.AdminService.AddNewAdminService.Execute(request));
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            var resGetAdminService = _services.AdminService.GetAdminService.Execute(Id);
            if(!resGetAdminService.IsSuccess)
            {
                return Json(resGetAdminService);
            }

            ReqEditAdminDto request = new ReqEditAdminDto()
            {
                Id = resGetAdminService.Data.Id,
                UserName = resGetAdminService.Data.UserName,
                Role = resGetAdminService.Data.Role
            };
            return View(request);
        }

        [HttpPost]
        public IActionResult Edit(ReqEditAdminDto request)
        {
            return Json(_services.AdminService.EditAdminService.Execute(request));
        }

        public IActionResult Remove (Guid Id)
        {
            return Json(_services.AdminService.RemoveAdminService.Execute(Id));
        }

        public  IActionResult Orders (Guid Id)
        {
            return View(_services.AdminService.GetAdminOrdersService.Execute(Id));
        }

        public IActionResult OrderDetails(Guid Id)
        {
            return View(_services.AdminService.GetAdminOrderDetailsService.Execute(Id));
        }
    }
}
