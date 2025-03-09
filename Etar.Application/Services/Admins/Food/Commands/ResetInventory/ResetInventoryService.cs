using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Admins.Food.Commands.ResetInventory
{
    public class ResetInventoryService : IResetInventoryService
    {
        private readonly IDataBaseContext _context;
        public ResetInventoryService(IDataBaseContext context)
        { 
            _context = context;
        }

        public Result Execute(Guid? id)
        { 
            if (id == null)
            {
                var foundedFoods = _context.foods.ToList();

                if (foundedFoods.Any())
                {
                    foreach(var food in foundedFoods)
                    {
                        food.Inventory = 0;
                    }

                    _context.SaveChanges();

                    return new Result()
                    {
                        IsSuccess = true,
                    };
                }

                return new Result()
                {
                    IsSuccess = false,
                    Message = "غذایی موجود نمیباشد"
                };
            }

            var foundedFood = _context.foods.Find(id);

            if(foundedFood != null)
            {
                foundedFood.Inventory = 0;
                _context.SaveChanges();

                return new Result()
                {
                    IsSuccess = true
                };
            }

            return new Result()
            {
                IsSuccess = false,
                Message = "غذایی پیدا نشد"
            };
        }

        public Result Execute(Guid catId)
        {
            var foundedFoods = _context.foods.Where(f => f.CatId == catId).ToList();

            if(foundedFoods.Any())
            {
                foreach (var food in foundedFoods)
                {
                    food.Inventory = 0;
                }
                _context.SaveChanges();

                return new Result()
                {
                    IsSuccess = true,
                };
            }

            return new Result()
            {
                IsSuccess = false,
                Message = "غذایی در این دسته بندی یافت نشد"
            };
        }
    }
}
