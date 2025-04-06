using Etar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Owners.Order.Queries.GetOrders
{
    public interface IGetOrdersService
    {
        Result<ResGetOrdersDto> Execute(GetOrdersBy ordersBy, string? adminName = null);
    }
}
