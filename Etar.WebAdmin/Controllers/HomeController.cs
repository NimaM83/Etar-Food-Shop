using Etar.Application.Interfaces.Services.Admin;
using Etar.Application.Services.Admins.User.Queries.SignInAdmin;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Etar.Common.Utilities;
using Etar.Domain.Entities.Users;

namespace Etar.WebAdmin.Controllers
{
    public class HomeController : Controller
    {

        private readonly IAdminServices _services;
        public HomeController(IAdminServices service)
        {
            _services = service;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(ReqSignInAdminDto request)
        {
            var result = _services.UserServices.signInAdminService.Execute(request);
            CookiesManager cookiesManager = new CookiesManager();

            if (result.IsSuccess)
            {
                var claims = new List<Claim>()
                {
                new Claim(ClaimTypes.NameIdentifier,result.Data.Id.ToString()),

                new Claim(ClaimTypes.Name, result.Data.UserName),

                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(1),
                };
                HttpContext.SignInAsync(principal, properties);
                cookiesManager.Add(HttpContext, "Id", result.Data.Id.ToString(), 1);

                if(result.Data.Role == EAdminRoles.Admin)
                {
                    return RedirectToAction("Index");
                }

                return Redirect("/Owner/Home/Index");
            }

            return Json(result);
        }

        public IActionResult Index()
        {
            return View();
        }
    
    }
}
