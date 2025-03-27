using Etar.Application.Interfaces.Context;
using Etar.Application.Services.Admins.Order.Commands.AddOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Order
{
    public interface IOrderService
    {
        IAddOrderService AddOrderService { get; }
    }

    public class OrderService : IOrderService
    {
        private readonly IDataBaseContext _context;
        public OrderService(IDataBaseContext context)
        { 
            _context = context;
        }

        private IAddOrderService _addOrder;
        public IAddOrderService AddOrderService
        {
            get
            { 
                return _addOrder = _addOrder ?? new AddOrderService(_context);
            }
        }
    }
}
