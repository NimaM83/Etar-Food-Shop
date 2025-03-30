using Etar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Owners.Admin.Queries.GetAdmins
{
    public interface IGetAdminsService
    {
        Result<List<ResAllAdminsDto>> Execute();
    }
}
