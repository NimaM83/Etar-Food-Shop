using Etar.Application.Interfaces.Context;
using Etar.Application.Services.Admins.User.Commands.AddNewAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.User
{
    public interface IUserService
    {
        //سرویس افزودن ادمین جدید
        IAddNewAdminService addNewAdminService { get; }
    }

    public class UserService :IUserService
    {
        private readonly IDataBaseContext _context;

        public UserService(IDataBaseContext context)
        {
            _context = context;
        }

        private IAddNewAdminService _addAdmin;
        public IAddNewAdminService addNewAdminService
        {
            get
            {
                return _addAdmin = _addAdmin ?? new AddNewAdminService(_context);
            }
        }
    }
}
