using Etar.Domain.Entities;
using Etar.Domain.Entities.Carts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Cart.Queries.GetCart
{
    public interface IGetCartService
    {
        Result<List<ResGetCartDto>> Execute (Guid adminId, bool IsFinisheds = false);
    }
}
