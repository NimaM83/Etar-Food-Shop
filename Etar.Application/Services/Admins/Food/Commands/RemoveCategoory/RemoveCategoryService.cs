using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Admins.Food.Commands.RemoveCategoory
{
    public class RemoveCategoryService : IRemoveCategoryService
    {
        private readonly IDataBaseContext _context;
        public RemoveCategoryService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute(Guid Id)
        {
            var foundedCategory = _context.foodCategories.Where(c => c.Id == Id).FirstOrDefault();

            if(foundedCategory != null)
            {
                _context.foodCategories.Remove(foundedCategory);
                _context.SaveChanges();

                return new Result()
                {
                    IsSuccess = true,
                    Message = "دسته بندی با موفقیت  حذف شد"
                };
            }

            return new Result()
            {
                IsSuccess = false,
                Message = "دسته بندی یافت نشد"
            };
        }
    }
}
