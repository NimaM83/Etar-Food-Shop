using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Admins.Food.Commands.RemoveFood
{
    public class RemoveFoodService : IRemoveFoodService
    {
        private readonly IDataBaseContext _context;

        public RemoveFoodService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute(Guid id)
        {
            var foundedFood = _context.foods.Find(id);

            if (foundedFood != null)
            { 
                _context.foods.Remove(foundedFood);
                _context.SaveChanges();

                return new Result()
                {
                    IsSuccess = true,
                    Message = "غذا با موفقیت حذف شد"
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
