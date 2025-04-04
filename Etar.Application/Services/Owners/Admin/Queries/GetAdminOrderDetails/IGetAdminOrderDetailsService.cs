using Etar.Domain.Entities;
using Etar.Domain.Entities.Carts;
using Etar.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Owners.Admin.Queries.GetAdminOrderDetails
{
    public interface IGetAdminOrderDetailsService
    {
        Result<ResAdminOrderDetailsDto> Execute(Guid orderId);
    }
}
