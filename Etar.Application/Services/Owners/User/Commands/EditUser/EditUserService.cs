using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Owners.User.Commands.EditUser
{
    public class EditUserService : IEditUserService
    {
        private readonly IDataBaseContext _context;
        public EditUserService(IDataBaseContext context)
        {
            _context = context;
        }   

        public Result Execute (ReqEditUserDto request)
        {
            var foundedUser = _context.admins.Find(request.Id);

            if(foundedUser != null)
            {
                if(foundedUser.UserName.Length >= 5)
                {
                    bool isValid  = !(_context.admins.Where(a => a.UserName.Equals(foundedUser.UserName))
                                    .Any());

                    if(isValid)
                    {
                        foundedUser.UserName = request.UserName;
                        _context.SaveChanges();

                        return new Result()
                        {
                            IsSuccess = true,
                            Message = "حساب کاربری با موفقیت ویرایش شد"
                        };
                    }

                    return new Result()
                    {
                        IsSuccess = false,
                        Message = "نام کاربری قبلا استفاده شده است"
                    }; ;
                }

                return new Result()
                {
                    IsSuccess = false,
                    Message = "نام کاربری باید حداقل 5 کارکتر باشد"
                };
            }

            return new Result()
            {
                IsSuccess = false,
                Message = "حساب کاربری یافت نشد"
            };
        }
    }
}
