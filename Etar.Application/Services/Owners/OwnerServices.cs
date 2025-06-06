﻿using Etar.Application.Interfaces.Context;
using Etar.Application.Interfaces.Services.Owner;

using Etar.Application.Services.Owners.Admin;
using Etar.Application.Services.Owners.Order;
using Etar.Application.Services.Owners.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Owners
{
    public class OwnerServices : IOwnerServices
    {
        private readonly IDataBaseContext _context;
        public OwnerServices(IDataBaseContext context)
        {
            _context = context;
        }

        private IAdminService _adminService;
        public IAdminService AdminService
        {
            get
            {
                return _adminService = _adminService ?? new AdminService(_context);
            }
        }

        private IUserService _userService;
        public IUserService UserService
        {
            get 
            {
                return  _userService = _userService ?? new UserService(_context);
            }
        }

        private IOrderService _orderService;
        public IOrderService OrderService
        {
            get 
            {
                return _orderService = _orderService ?? new OrderService(_context);
            }
        }
    }
}
