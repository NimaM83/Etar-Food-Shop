using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Admins.Food.Commands.UpdateCategory
{
    public class UpdateCategoryService : IUpdateCategoryService
    {
        private readonly IDataBaseContext _context;
        public UpdateCategoryService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute (ReqUpdateCategoryDto request)
        {
            var foundedCategory = _context.foodCategories.Find(request.Id);
            
            if(foundedCategory != null)
            {
                foundedCategory.Name = request.Name;
                _context.SaveChanges();

                return new Result()
                {
                    IsSuccess = true,
                    Message = "تفییرات با موفقیت اعمال شد"
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
