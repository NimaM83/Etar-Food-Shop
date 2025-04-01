using Etar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Owners.Admin.Commands.EditAdmin
{
    public interface IEditAdminService
    {
        Result Execute(ReqEditAdminDto request);
    }
}
