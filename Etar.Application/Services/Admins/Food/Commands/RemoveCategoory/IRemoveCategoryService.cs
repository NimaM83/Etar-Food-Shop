using Etar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Food.Commands.RemoveCategoory
{
    public interface IRemoveCategoryService
    {
        Result Execute(Guid Id);
    }
}
