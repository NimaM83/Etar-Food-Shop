using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;
using Etar.Domain.Entities.Foods;
using Microsoft.EntityFrameworkCore;

namespace Etar.Application.Services.Admins.Food.Commands.AddFood
{
    public class AddFoodService : IAddFoodService
    {
        private readonly IDataBaseContext _context;
        public AddFoodService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute (ReqAddFoodDto request)
        {
            FoodCategory category = _context.foodCategories.Where(c => c.Id==request.CategoryId).FirstOrDefault();
            var foundedFood = _context.foods.Include(f => f.Category)
                               .Where(f => f.Name.Equals(request.Name) && f.Category.Name.Equals(category.Name))
                               .FirstOrDefault();

            if(foundedFood == null)
            {
                _context.foods.Add(new Domain.Entities.Foods.Food()
                {
                    Name = request.Name,
                    Description = request.Description,
                    CatId = request.CategoryId,
                    Category = category,
                    Price = request.Price,
                    Inventory = 0
                });
                _context.SaveChanges();

                return new Result()
                {
                    IsSuccess = true,
                    Message = "غذا با موفقیت افزوده شد"
                };
            }

            return new Result()
            {
                IsSuccess = false,
                Message = "غذایی با این نام و دسته بندی موجود میباشد"
            };
        
        }
    }
}
