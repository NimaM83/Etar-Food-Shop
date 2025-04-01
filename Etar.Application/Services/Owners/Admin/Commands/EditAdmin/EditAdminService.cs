using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Owners.Admin.Commands.EditAdmin
{
    public class EditAdminService : IEditAdminService
    {
        private readonly IDataBaseContext _context;
        public EditAdminService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute (ReqEditAdminDto request)
        {
            if(request.UserName.Length >= 5)
            {
                var foundedAdmin = _context.admins.Where(a => a.UserName == request.UserName).FirstOrDefault();

                if(foundedAdmin == null)
                {
                    if(request.Password.Length >= 8)
                    {
                        if(request.Password.Equals(request.RePassword))
                        {
                            var admin = _context.admins.Find(request.Id);

                            admin.UserName = request.UserName;
                            admin.Password = request.Password;
                            admin.Role = request.Role;
                            _context.SaveChanges();

                            return new Result()
                            {
                                IsSuccess = true,
                                Message = "ادمین با موفقیت ویرایش شد"
                            }; 
                        }

                        return new Result()
                        {
                            IsSuccess = false,
                            Message = "رمز عبور با تکرار آن برابر نیست"
                        };
                    }

                    return new Result()
                    {
                        IsSuccess = false,
                        Message = "رمز عبور باید حداقل 8 کارکتر باشد"
                    };
                }

                return new Result()
                {
                    IsSuccess = false,
                    Message = "ادمینی با این نام کاربری موجود است"
                };
            }

            return new Result()
            {
                IsSuccess = false,
                Message = "نام کاربری باید حداقل 5 کارکتر داشته باشد"
            };
        }
    }
}
