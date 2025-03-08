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

        public Result<List<ResGetFoodsDto>> Execute()
        {
            var foundedFoods = _context.foods.Include(f => f.Category).ToList();

            if(foundedFoods.Count() > 0)
            {
                List<ResGetFoodsDto> foods = new List<ResGetFoodsDto>();

                foreach(var item in foundedFoods)
                {
                    foods.Add(new ResGetFoodsDto()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Category = item.Category.Name,
                        Price = item.Price,
                        Inventory = item.Inventory,
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
    }
}
