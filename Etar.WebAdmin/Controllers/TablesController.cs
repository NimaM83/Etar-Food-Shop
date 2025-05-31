using Etar.Application.Interfaces.Services.Admin;
using Etar.Application.Services.Admins.Table.Commands.AddTable;
using Etar.Application.Services.Admins.Table.Commands.ReservationTable;
using Microsoft.AspNetCore.Mvc;

namespace Etar.WebAdmin.Controllers
{
    public class TablesController : Controller
    {
        private readonly IAdminServices _services;
        public TablesController(IAdminServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            return View(_services.TableServices.GetTablesService.Execute());
        }

        [HttpGet]
        public  IActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create (ReqAddTableDto request)
        {
            return  Json(_services.TableServices.AddTableService.Execute(request));
        }

        [HttpGet]
        public IActionResult Reserve(Guid id)
        {
            ViewBag.TableId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Reserve(ReqReservationTableDto request)
        {
            return Json(_services.TableServices.ReservationTableService.Execute(request));
        }
    }
}
