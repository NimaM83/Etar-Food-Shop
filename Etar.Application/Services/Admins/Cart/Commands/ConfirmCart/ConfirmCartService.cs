using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Admins.Cart.Commands.ConfirmCart
{
    public class ConfirmCartService : IConfirmCartService
    {
        private readonly IDataBaseContext _context;
        public ConfirmCartService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute(Guid cartId)
        {
            var foundedCart = _context.adminCarts.Find(cartId);

            if(foundedCart != null)
            {
                foundedCart.IsFinished = true;
                _context.SaveChanges();

                return new Result()
                {
                    IsSuccess = true,
                    Message = "سبد با موفقیت تایید شد"
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
