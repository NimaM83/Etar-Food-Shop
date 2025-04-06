using Etar.Application.Services.Owners.Admin.Queries.GetAdminOrderDetails;
using Etar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Owners.Order.Queries.GetOrderDetails
{
    public interface IGetOrderDetailsService
    {
        Result<ResOrderDetailsDto> Execute(Guid orderId);
    }
}
