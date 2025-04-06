using Etar.Application.Interfaces.Context;
using Etar.Application.Services.Owners.Order.Queries.GetOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Owners.Order
{
    public interface IOrderService
    {
        IGetOrdersService GetOrdersService { get; }
    }

    public class OrderService : IOrderService
    {
        private readonly IDataBaseContext _context;
        public OrderService(IDataBaseContext context)
        {
            _context = context;
        }

        private IGetOrdersService _ordersService;
        public IGetOrdersService GetOrdersService
        {
            get
            {
                return _ordersService = _ordersService ?? new GetOrdersService(_context);
            }
        }
    }
}
