using Etar.Application.Interfaces.Services.Owner;
using Etar.Application.Services.Owners.Order.Queries.GetOrders;
using Microsoft.AspNetCore.Mvc;

namespace Etar.WebAdmin.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class OrderController : Controller
    {
        private readonly IOwnerServices _services;
        public OrderController (IOwnerServices services)
        {
            _services = services;
        }
        public IActionResult Index(GetOrdersBy orderBy = GetOrdersBy.All, string? adminName = null)
        {
            ViewBag.Admins = _services.AdminService.GetAdminsService.Execute().Data;
            return View(_services.OrderService.GetOrdersService.Execute(orderBy, adminName));
        }

        public IActionResult Details(Guid orderId)
        {
            return View(_services.OrderService.GetOrderDetailsService.Execute(orderId));
        }
    }
}
