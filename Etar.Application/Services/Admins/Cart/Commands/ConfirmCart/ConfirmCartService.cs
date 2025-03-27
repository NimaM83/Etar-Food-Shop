using Etar.Application.Interfaces.Context;
using Etar.Application.Interfaces.Services.Admin;
using Etar.Application.Services.Admins.Order;
using Etar.Domain.Entities;
using Etar.Domain.Entities.Orders;

namespace Etar.Application.Services.Admins.Cart.Commands.ConfirmCart
{
    public class ConfirmCartService : IConfirmCartService
    {
        private readonly IDataBaseContext _context;
        private readonly IOrderService _orderService;
        public ConfirmCartService(IDataBaseContext context, IOrderService orderService)
        {
            _orderService = orderService;
            _context = context;
        }

        public Result Execute(Guid cartId)
        {
            var foundedCart = _context.adminCarts.Find(cartId);

            if(foundedCart != null)
            {
                foundedCart.IsFinished = true;
                _context.SaveChanges();

                Result res = _orderService.AddOrderService.Execute(cartId, EOrderUser.Admin);

                return new Result()
                {
                    IsSuccess = res.IsSuccess,
                    Message = res.Message
                };
            }

            return new Result()
            {
                IsSuccess = false,
                Message = "سبد یافت نشد"
            };
        }
    }
}
