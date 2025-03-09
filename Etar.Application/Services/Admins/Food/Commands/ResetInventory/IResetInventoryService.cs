using Etar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Food.Commands.ResetInventory
{
    public interface IResetInventoryService
    {
        Result Execute(Guid? id);
        Result Execute(Guid catId);
    }
}
