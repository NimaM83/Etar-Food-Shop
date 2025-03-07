using Etar.Application.Services.Admins.User.Queries.GetAdmins;
using Etar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.User.Commands.RemoveAdmin
{
    public interface IRemoveAdminService
    {
        Result Execute(Guid Id);
    }
}
