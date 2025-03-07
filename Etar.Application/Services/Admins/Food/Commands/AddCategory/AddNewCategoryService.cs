using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;
using Etar.Domain.Entities.Foods;

namespace Etar.Application.Services.Admins.Food.Commands.AddCategory
{
    public class AddNewCategoryService : IAddNewCategoryService
    {
        private readonly IDataBaseContext _context;

        public AddNewCategoryService(IDataBaseContext context)
        {
            _context = context; 
        }

        public Result Execute (string name)
        {
            bool isValid = (_context.foodCategories.Where(c => c.Name == name)
                           .FirstOrDefault() == null) ? true : false;

            if(isValid)
            {
                _context.foodCategories.Add(new FoodCategory()
                {
                    Name = name,
                });
                _context.SaveChanges();

                return new Result()
                {
                    IsSuccess = true,
                    Message = "دسته بندی با موفقیت افزوده شد."
                };
            }

            return new Result()
            {
                IsSuccess = false,
                Message = "این دسته بندی از قبل موجود است"
            };

        }

    }
}
