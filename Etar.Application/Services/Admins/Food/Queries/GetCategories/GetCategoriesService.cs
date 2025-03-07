using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;
using Etar.Domain.Entities.Foods;

namespace Etar.Application.Services.Admins.Food.Queries.GetCategories
{
    public class GetCategoriesService : IGetCategoriesService
    {
        private readonly IDataBaseContext _context;
        public GetCategoriesService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result<ResGetCategoriesDto> Execute(Guid? Id)
        {
            if (Id == null)
            {
                var foundedCategories = _context.foodCategories.ToList();

                if (foundedCategories.Count() > 0)
                {
                    return new Result<ResGetCategoriesDto>()
                    {
                        IsSuccess = true,
                        Message = "",

                        Data = new ResGetCategoriesDto()
                        {
                            Categories = foundedCategories,
                        }
                    };
                }

                return new Result<ResGetCategoriesDto>()
                {
                    IsSuccess = false,
                    Message = "لیست دسته بندی ها خالیست"
                };
            }

            var foundedCategory = _context.foodCategories.Where(C => C.Id == Id).FirstOrDefault();
            if (foundedCategory != null)
            {
                List<FoodCategory> category = new List<FoodCategory>();
                category.Add(foundedCategory);

                return new Result<ResGetCategoriesDto>()
                {
                    IsSuccess = true,
                    Message = "",

                    Data = new ResGetCategoriesDto()
                    {
                        Categories = category
                    }
                };
            }

            return new Result<ResGetCategoriesDto>()
            {
                IsSuccess = false,
                Message = "دسته بندی  مورد نظر یافت نشد"
            };



           


        }

    }
}
