using Etar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Food.Commands.UpdateInvenroy
{
    public interface IUpdateInventoryService
    {
        Result Execute (Guid id, int editAmount);
    }
}
