using Etar.Application.Interfaces.Context;
using Etar.Application.Services.Owners.User.Commands.EditUser;
using Etar.Application.Services.Owners.User.Queries.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Owners.User
{
    public interface IUserService
    {
        IGetUserService GetUserService { get; }
        IEditUserService EditUserService { get; }
    }

    public class UserService : IUserService
    {
        private readonly IDataBaseContext _context;
        public UserService(IDataBaseContext context)
        {
            _context = context;
        }

        private IGetUserService _getuser;
        public IGetUserService GetUserService
        {
            get
            {
                return _getuser = _getuser ?? new GetUserService(_context);
            }
        }

        private IEditUserService _editUser;
        public IEditUserService  EditUserService
        {
            get
            {
                return _editUser = _editUser ?? new EditUserService(_context);
            }
        }
    }
}
