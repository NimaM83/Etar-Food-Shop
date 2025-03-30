using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Owners.Admin.Commands.RemoveAdmin
{
    public class RemoveAdminService : IRemoveAdminService
    {
        private readonly IDataBaseContext _context;

        public RemoveAdminService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute(Guid Id)
        {
            var foundedAdmin = _context.admins.Where(a => a.Id == Id).FirstOrDefault();

            if (foundedAdmin != null)
            {
                _context.admins.Remove(foundedAdmin);
                _context.SaveChanges();

                return new Result()
                {
                    IsSuccess = true,
                    Message = "ادمین با موفقیت حذف شد"
                };
            }

            return new Result()
            {
                IsSuccess = false,
                Message = "ادمین پیدا نشد"
            };
        }
    }
}
