using Etar.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Owners.User.Commands.EditUser
{
    public interface IEditUserService
    {
        Result Execute(ReqEditUserDto request);
    }
}
