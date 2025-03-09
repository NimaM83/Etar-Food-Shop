using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Admins.Food.Commands.UpdateFood
{
    public class UpdateFoodService : IUpdateFoodService
    {
        private readonly IDataBaseContext _context;
        public UpdateFoodService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute (ReqUpdateFoodDto request)
        {
            var foundedFood = _context.foods.Find(request.Id);

            if(foundedFood != null)
            {
                foundedFood.Name = request.Name;
                foundedFood.Price = request.Price;
                foundedFood.Description = request.Description;
                foundedFood.CatId = request.CategoryId;
                foundedFood.Category = _context.foodCategories.Find(foundedFood.CatId);

                _context.SaveChanges();

                return new Result()
                {
                    IsSuccess = true,
                    Message = "غذا با موفقیت ویرایش شد"
                };
            }

            return new Result()
            {
                IsSuccess = false,
                Message = "غذای مورد نظر یافت نشد"
            };
                              
        }
    }
}
