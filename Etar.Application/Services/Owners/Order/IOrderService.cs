using Etar.Application.Interfaces.Context;
using Etar.Application.Services.Owners.Order.Queries.GetOrderDetails;
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
        IGetOrderDetailsService GetOrderDetailsService { get; }
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

        private IGetOrderDetailsService _orderDetailsService;
        public IGetOrderDetailsService GetOrderDetailsService
        {
            get
            {
               return _orderDetailsService = _orderDetailsService ?? new GetOrderDetailsService(_context);
            }
        }
    }
}
