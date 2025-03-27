using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;
using Etar.Domain.Entities.Orders;

namespace Etar.Application.Services.Admins.Order.Commands.AddOrder
{
    public class AddOrderService : IAddOrderService
    {
        private readonly IDataBaseContext _context;
        public AddOrderService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute(Guid cartId, EOrderUser user)
        {
            if (user == EOrderUser.Admin)
            {
                var foundedCart = _context.adminCarts.Where(c => c.Id == cartId)
                                  .FirstOrDefault();

                if (foundedCart != null)
                {
                    _context.orders.Add(new Domain.Entities.Orders.Order()
                    {
                        CartId = cartId,
                        UserId = foundedCart.AdminId,
                        TotalPrice = foundedCart.TotalPrice,
                        User = EOrderUser.Admin,
                    });
                    _context.SaveChanges();

                    return new Result()
                    {
                        IsSuccess = true,
                        Message = "سفارش با موفقیت ثبت شد"
                    };

                }

                return new Result()
                {
                    IsSuccess = false,
                    Message = "سبدی یافت نشد"
                };
            }

            //first implement the clients cart 
            return null;
        }
    }
}
