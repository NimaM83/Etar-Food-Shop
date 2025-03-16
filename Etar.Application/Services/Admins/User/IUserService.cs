using Etar.Application.Interfaces.Context;
using Etar.Application.Services.Admins.User.Commands.AddNewAdmin;
using Etar.Application.Services.Admins.User.Commands.RemoveAdmin;
using Etar.Application.Services.Admins.User.Queries.GetAdmins;
using Etar.Application.Services.Admins.User.Queries.SignInAdmin;
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
        IGetAdminsService getAdminsService { get; }
        IRemoveAdminService removeAdminService { get; }
        ISignInAdminService signInAdminService { get; }
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

        private IGetAdminsService _getAdmins;
        public IGetAdminsService getAdminsService
        {
            get
            {
                return _getAdmins = _getAdmins ?? new GetAdminsService(_context);
            }
        }

        private IRemoveAdminService _removeAdmin;
        public IRemoveAdminService removeAdminService
        {
            get
            {

                return _removeAdmin = _removeAdmin ?? new RemoveAdminService(_context);
            }
        }

        private ISignInAdminService _signInAdmin;
        public ISignInAdminService signInAdminService
        {
            get
            {
                return _signInAdmin = _signInAdmin ?? new SignInAdminService(_context);
            }
        }
    }
}
