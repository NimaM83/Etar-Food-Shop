using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Admins.Cart.Commands.RemoveItem
{
    public class RemoveItemService : IRemoveItemService
    {
        private readonly IDataBaseContext _context;
        public RemoveItemService(IDataBaseContext context)
        { 
            _context = context;
        }

        public Result Execute(Guid foodId, Guid adminId, bool IsDecrease = false)
        { 
            var foundedFood = _context.foods.Find(foodId);

            if (foundedFood != null)
            { 
                var foundedCart = _context.adminCarts.Where(c => c.AdminId == adminId && !c.IsFinished).FirstOrDefault();

                if(foundedCart != null)
                {
                    var itemInCart = _context.adminCartItems.Where(i => i.CartId == foundedCart.Id && i.FoodId == foundedFood.Id)
                                     .FirstOrDefault();

                    if (itemInCart != null)
                    {
                        if (IsDecrease)
                        { 
                            if(itemInCart.count > 0)
                            {
                                itemInCart.count--;
                                itemInCart.PriceForCount -= itemInCart.PriceForOne;
                                foundedCart.TotalPrice -= itemInCart.PriceForOne;
                                _context.SaveChanges();

                                return new Result()
                                {
                                    IsSuccess = true,
                                    Message = "غذا با موفقیت کاهش یافت"
                                };
                            }
                        }

                        foundedCart.TotalPrice -= itemInCart.PriceForCount;
                        _context.adminCartItems.Remove(itemInCart);
                        _context.SaveChanges();

                        return new Result()
                        {
                            IsSuccess = true,
                            Message = "غذا با موفقیت از سبد حذف شد"
                        };

                    }

                    return new Result()
                    {
                        IsSuccess = false,
                        Message = "این غذا در سبد موجود نمیباشد"
                    };
                }

                return new Result()
                {
                    IsSuccess = false,
                    Message = "سبدی یافت نشد"
                };
            }

            return new Result()
            {
                IsSuccess = false,
                Message = "غذایی یافت نشد"
            };
        }
    }
}
