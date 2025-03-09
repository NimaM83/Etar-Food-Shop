using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Etar.Application.Services.Admins.Food.Queries.GetFoods
{
    public class GetFoodsService : IGetFoodsService
    {
        private readonly IDataBaseContext _context;
        public GetFoodsService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result<List<ResGetFoodsDto>> Execute(Guid? catId)
        {

            if (catId == null)
            {
                var foundedFoods = _context.foods.Include(f => f.Category).ToList();

                if (foundedFoods.Count() > 0)
                {
                    List<ResGetFoodsDto> foods = new List<ResGetFoodsDto>();

                    foreach (var item in foundedFoods)
                    {
                        foods.Add(new ResGetFoodsDto()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Category = item.Category.Name,
                            Price = item.Price,
                            Inventory = item.Inventory,
                            catId = item.Category.Id
                        });
                    }

                    return new Result<List<ResGetFoodsDto>>()
                    {
                        Data = foods,
                        IsSuccess = true,
                        Message = ""
                    };
                }

                return new Result<List<ResGetFoodsDto>>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "غذایی پیدا نشد"
                };
            }

            var foundedCatFoods = _context.foods.Where(f => f.CatId == catId)
                              .Include(f => f.Category).ToList();

            if(foundedCatFoods.Count() > 0)
            {
                List<ResGetFoodsDto> foods = new List<ResGetFoodsDto>();

                foreach (var item in foundedCatFoods)
                {
                    foods.Add(new ResGetFoodsDto()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Category = item.Category.Name,
                        Price = item.Price,
                        Inventory = item.Inventory,
                        catId = item.CatId
                    });
                }

                return new Result<List<ResGetFoodsDto>>()
                {
                    Data = foods,
                    IsSuccess = true,
                    Message = ""
                };
            }

            return new Result<List<ResGetFoodsDto>>()
            {
                Data = null,
                IsSuccess = false,
                Message = "غذایی در این دسته بندی موجود نمیباشد"
            };
           
        }

        public Result<ResGetFoodDto> Execute (Guid id)
        {
            var foundedFood = _context.foods.Where(f => f.Id == id).FirstOrDefault();

            if(foundedFood != null)
            {
                return new Result<ResGetFoodDto>()
                {
                    IsSuccess = true,
                    Message = "غذای مورد نظر با موفقیت دریافت شد",

                    Data = new ResGetFoodDto()
                    {
                        Id = foundedFood.Id,
                        Name = foundedFood.Name,
                        Description = foundedFood.Description,
                        CategoryId = foundedFood.CatId,
                        Price = foundedFood.Price,
                    }
                };
            }

            return new Result<ResGetFoodDto>()
            {
                Data = null,
                IsSuccess = false,
                Message = "غذای مورد نظر یافت نشد"
            };
        }
    }
}
