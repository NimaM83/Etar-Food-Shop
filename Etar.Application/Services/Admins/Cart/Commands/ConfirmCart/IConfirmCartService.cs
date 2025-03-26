using Etar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Cart.Commands.ConfirmCart
{
    public interface IConfirmCartService
    {
        Result Execute(Guid cartId);
    }
}
