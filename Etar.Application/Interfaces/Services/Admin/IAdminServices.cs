using Etar.Application.Services.Admins.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Interfaces.Services.Admin
{
    public interface IAdminServices
    {
        IUserService UserServices { get; }
    }
}
