using Etar.Application.Interfaces.Context;
using Etar.Application.Interfaces.Services.Owner;
using Etar.Application.Services.Owners.Admin;
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
    }
}
