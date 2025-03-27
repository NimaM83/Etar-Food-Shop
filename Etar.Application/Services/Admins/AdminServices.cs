using Etar.Application.Interfaces.Context;
using Etar.Application.Interfaces.Services.Admin;
using Etar.Application.Services.Admins.Cart;
using Etar.Application.Services.Admins.Food;
using Etar.Application.Services.Admins.Order;
using Etar.Application.Services.Admins.Table;
using Etar.Application.Services.Admins.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins
{
    public class AdminServices : IAdminServices
    {
        private readonly IDataBaseContext _context;
        public AdminServices(IDataBaseContext context)
        {
            _context = context;
        }

        private IUserService _userServices;
        public IUserService UserServices
        {
            get
            {
                return _userServices = _userServices ?? new UserService(_context);
            }
        }

        private IFoodService _foodService;
        public IFoodService FoodServices
        {
            get
            {
                return _foodService = _foodService ?? new FoodService(_context);    
            }
        }

        private ITableService _tableService;
        public ITableService TableServices
        {
            get
            {
                return _tableService = _tableService?? new TableService(_context);
            }
        }

        private ICartService _cartServices;
        public ICartService CartServices
        {
            get
            {
                return _cartServices = _cartServices ?? new CartService(_context, OrderServices);
            }
        }

        private IOrderService _orderServices;
        public IOrderService OrderServices
        {
            get
            {
                return _orderServices = _orderServices ?? new OrderService(_context);
            }
        }
    }
}
