using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Etar.Application.Services.Admins.Cart.Queries.GetCartDetails
{
    public class GetCartDetailsService : IGetCartDetailsService
    {
        private readonly IDataBaseContext _context;
        public GetCartDetailsService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result<CartDetailsDto> Execute(Guid cartId)
        {
            var foundedCart = _context.adminCarts.Where(c => c.Id == cartId)
                               .Include(c => c.Admin)
                               .FirstOrDefault();

            if(foundedCart !=  null)
            {
                var foundedItems = _context.adminCartItems.Where(i => i.CartId == cartId)
                                    .Include(i => i.Food)
                                    .ToList();

                List<CartDetilasItemDto> items = new List<CartDetilasItemDto>(); 
                foreach(var item in foundedItems)
                {
                    items.Add(new CartDetilasItemDto()
                    {
                        FoodName  =  item.Food.Name,
                        count  =  item.count,
                        PriceForCount = item.PriceForCount,
                        PriceForOne = item.PriceForOne
                    });
                }

                CartDetailsDto result = new CartDetailsDto()
                {
                    AdminName = foundedCart.Admin.UserName,
                    TotalPrice = foundedCart.TotalPrice,
                    Items = items
                };

                return new Result<CartDetailsDto>()
                {
                    IsSuccess = true,
                    Data = result,
                    Message = "سبد با  موفقیت   دریافت  شد"
                };
            }

            return new Result<CartDetailsDto>()
            {
                IsSuccess = false,
                Message = "سبد یافت نشد"
            };
        }
    }
}
