using Etar.Application.Interfaces.Services.Owner;
using Etar.Application.Services.Owners.User.Commands.ChangePass;
using Etar.Application.Services.Owners.User.Commands.EditUser;
using Etar.Common.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Etar.WebAdmin.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class UserController : Controller
    {
        private readonly IOwnerServices _services;
        private readonly CookiesManager _cookiesManager;
        public UserController(IOwnerServices services)
        {
            _services = services;
            _cookiesManager = new CookiesManager();
        }

        public IActionResult Index()
        {
            Guid userId = Guid.Parse(_cookiesManager.GetValue(HttpContext, "id"));
            return View(_services.UserService.GetUserService.Execute(userId));
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var result = _services.UserService.GetUserService.Execute(id);
            ReqEditUserDto request = new ReqEditUserDto()
            {
                Id = id,
                UserName = result.Data.UserName,
            };
            return View(request);
        }

        [HttpPost]
        public IActionResult Edit(ReqEditUserDto request)
        {
            return Json(_services.UserService.EditUserService.Execute(request));
        }

        [HttpGet]
        public IActionResult ChangePass()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePass(ReqChangePassDto request)
        {
            request.OwnerId = Guid.Parse(_cookiesManager.GetValue(HttpContext, "id"));
            return Json(_services.UserService.ChangePassService.Execute(request));
        }
    }
}
