using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Etar.Application.Services.Owners.Admin.Queries.GetAdminOrderDetails
{
    public class GetAdminOrderDetailsService : IGetAdminOrderDetailsService
    {
        private readonly IDataBaseContext _context;
        public GetAdminOrderDetailsService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result<ResAdminOrderDetailsDto> Execute(Guid orderId)
        {
            var foundedOrder = _context.adminOrders.Where(o => o.Id == orderId)
                               .Include(o => o.Cart)
                               .ThenInclude(c => c.Admin)
                               .FirstOrDefault();

            if(foundedOrder !=  null)
            {
                var foundedItems = _context.adminCartItems.Where(i => i.CartId == foundedOrder.CartId)
                                   .Include(i => i.Food) 
                                   .ToList();

                List<OrderDetailsItemDto> items = new List<OrderDetailsItemDto>();
                foreach(var  item in foundedItems)
                {
                    items.Add(new OrderDetailsItemDto()
                    {
                        FoodName = item.Food.Name,
                        Count = item.count,
                        PriceForCount = item.PriceForCount,
                        PriceForOne = item.PriceForOne
                    });
                }

                return new Result<ResAdminOrderDetailsDto>()
                {
                    Data = new ResAdminOrderDetailsDto()
                    {
                        TotalPrice = foundedOrder.TotalPrice,
                        AdminName = foundedOrder.Cart.Admin.UserName,
                        RegisterTime = foundedOrder.RegisterTime.ToLongDateString() + " / "
                                       + foundedOrder.RegisterTime.ToShortTimeString,
                    },

                    IsSuccess = true,
                    Message  =  "جزئیات با موفقیت  دریافت شد"

                };
            }

            return new Result<ResAdminOrderDetailsDto>()
            {
                IsSuccess = false,
                Message = "سفارش یافت نشد"
            };
        }
    }
}
