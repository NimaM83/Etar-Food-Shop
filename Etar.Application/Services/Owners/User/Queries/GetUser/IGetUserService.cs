using Etar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Owners.User.Queries.GetUser
{
    public interface IGetUserService
    {
        Result<ResGetUserDto> Execute(Guid Id);
    }
}
