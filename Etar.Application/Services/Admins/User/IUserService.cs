using Etar.Application.Interfaces.Context;
using Etar.Application.Services.Admins.User.Queries.SignInAdmin;

namespace Etar.Application.Services.Admins.User
{
    public interface IUserService
    {
        ISignInAdminService signInAdminService { get; }
    }

    public class UserService :IUserService
    {
        private readonly IDataBaseContext _context;

        public UserService(IDataBaseContext context)
        {
            _context = context;
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
