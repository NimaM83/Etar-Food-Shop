using Etar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Owners.User.Commands.ChangePass
{
    public interface IChangePassService
    {
        Result Execute (ReqChangePassDto request);
    }
}
