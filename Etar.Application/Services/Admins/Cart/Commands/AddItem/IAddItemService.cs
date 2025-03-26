using Etar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Cart.Commands.AddItem
{
    public interface IAddItemService
    {
        Result Execute(Guid foodId, Guid adminId);
    }
}
