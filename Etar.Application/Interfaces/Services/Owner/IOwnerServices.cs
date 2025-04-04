using Etar.Application.Services.Admins.User;
using Etar.Application.Services.Owners.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Interfaces.Services.Owner
{
    public interface IOwnerServices
    {
        IAdminService AdminService { get; }
        IUserService UserService { get; }
    }
}
