using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;
using Etar.Domain.Entities.Carts;

namespace Etar.Application.Services.Admins.Cart.Commands.AddItem
{
    public class AddItemService : IAddItemService
    {
        private readonly IDataBaseContext _context;

        public AddItemService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute(Guid foodId, Guid adminId)
        { 
            var foundedFood = _context.foods.Find(foodId);

            if (foundedFood != null)
            {
                var cart = _context.adminCarts.Where(c => c.AdminId == adminId && !c.IsFinished).FirstOrDefault();

                if (cart == null)
                {
                    cart = new AdminCart()
                    {
                        Admin = _context.admins.Find(adminId),
                        AdminId = adminId,
                        TotalPrice = 0,
                        IsFinished = false,
                    };

                    _context.adminCarts.Add(cart);
                    _context.SaveChanges();
                }

                var itemInCart = _context.adminCartItems.Where(i => i.CartId == cart.Id && i.FoodId == foodId)
                                 .FirstOrDefault();

                if (itemInCart == null)
                {
                    AdminCartItem item = new AdminCartItem()
                    {
                        CartId = cart.Id,
                        Cart = cart,
                        FoodId = foodId,
                        Food = foundedFood,
                        count = 1,
                        PriceForOne = foundedFood.Price,
                        PriceForCount = foundedFood.Price,
                    };

                    cart.TotalPrice += item.PriceForCount;
                    _context.adminCartItems.Add(item);
                    _context.SaveChanges();

                    return new Result()
                    {
                        IsSuccess = true,
                        Message = "غذا با موفقیت به سبد اضافه شد"
                    };
                }

                itemInCart.count++;
                itemInCart.PriceForCount += itemInCart.PriceForOne;
                cart.TotalPrice += itemInCart.PriceForOne;
                _context.SaveChanges();

                return new Result()
                {
                    IsSuccess = true,
                    Message = "غذا با موفقیت افزایش یافت"
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
