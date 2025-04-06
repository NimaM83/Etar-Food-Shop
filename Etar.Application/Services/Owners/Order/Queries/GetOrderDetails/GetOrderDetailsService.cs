using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Etar.Application.Services.Owners.Order.Queries.GetOrderDetails
{
    public class GetOrderDetailsService : IGetOrderDetailsService
    {
        private readonly IDataBaseContext _context;
        public GetOrderDetailsService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result<ResOrderDetailsDto> Execute(Guid orderId)
        {
            var foundedOrder = _context.adminOrders.Where(o => o.Id == orderId)
                               .Include(o => o.Cart)
                               .ThenInclude(c => c.Admin)
                               .FirstOrDefault();

            if (foundedOrder != null)
            {
                var foundedItems = _context.adminCartItems.Where(i => i.CartId == foundedOrder.CartId)
                                   .Include(i => i.Food)
                                   .ToList();

                List<OrderDetailsItemDto> items = new List<OrderDetailsItemDto>();
                foreach (var item in foundedItems)
                {
                    items.Add(new OrderDetailsItemDto()
                    {
                        FoodName = item.Food.Name,
                        Count = item.count,
                        PriceForCount = item.PriceForCount,
                        PriceForOne = item.PriceForOne
                    });
                }

                return new Result<ResOrderDetailsDto>()
                {
                    Data = new ResOrderDetailsDto()
                    {
                        TotalPrice = foundedOrder.TotalPrice,
                        AdminName = foundedOrder.Cart.Admin.UserName,
                        RegisterTime = foundedOrder.RegisterTime.ToLongDateString() + " / "
                                       + foundedOrder.RegisterTime.ToShortTimeString(),
                        Items = items,
                    },

                    IsSuccess = true,
                    Message = "جزئیات با موفقیت  دریافت شد"

                };
            }

            return new Result<ResOrderDetailsDto>()
            {
                IsSuccess = false,
                Message = "سفارش یافت نشد"
            };
        }
    }
}
