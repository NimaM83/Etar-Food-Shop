using Etar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Cart.Queries.GetCartDetails
{
    public interface IGetCartDetailsService
    {
        Result<CartDetailsDto> Execute(Guid cartId);
    }
}
