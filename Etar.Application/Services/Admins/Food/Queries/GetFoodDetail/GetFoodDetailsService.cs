using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Etar.Application.Services.Admins.Food.Queries.GetFoodDetail
{
    public class GetFoodDetailsService : IGetFoodDetaisService
    {
        private readonly IDataBaseContext _context;
        public GetFoodDetailsService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result<ResGetFoodDetailsDto> Execute (Guid id)
        {
            var foundedFood = _context.foods.Where(f => f.Id==id)
                              .Include(f => f.Category)
                              .FirstOrDefault();

            if(foundedFood != null)
            {
                ResGetFoodDetailsDto result = new ResGetFoodDetailsDto()
                {
                    Id = foundedFood.Id,
                    Name = foundedFood.Name,
                    Description = foundedFood.Description,
                    Price = foundedFood.Price,
                    Category = foundedFood.Category.Name,
                };

                return new Result<ResGetFoodDetailsDto>()
                {
                    Data = result,
                    IsSuccess = true,
                    Message = "جزئیات غذا با موفقیت دریافت شد"
                };
            }

            return new Result<ResGetFoodDetailsDto>
            {
                Data = null,
                IsSuccess = false,
                Message = "غذایی یافت نشد"
            };
        }
    }
}
