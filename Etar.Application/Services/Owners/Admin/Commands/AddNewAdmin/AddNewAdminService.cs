using Etar.Application.Interfaces.Context;
using Etar.Common;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Owners.Admin.Commands.AddNewAdmin
{
    public class AddNewAdminService : IAddNewAdminService
    {
        private readonly IDataBaseContext _context;

        public AddNewAdminService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute(ReqAddNewAdminDto request)
        {
            if (request.UserName.Length >= 5)
            {
                // ادمینی با نام کاربری مشابه
                var foundedAdmin = _context.admins.Where(a => a.UserName == request.UserName).FirstOrDefault();

                if (foundedAdmin == null)
                {
                    if (request.Password.Length >= 8)
                    {
                        if (request.Password == request.RePassword)
                        {
                            PasswordHasher hasher = new PasswordHasher();
                            _context.admins.Add(new Domain.Entities.Users.Admin()
                            {
                                UserName = request.UserName,
                                Password = hasher.HashPassword(request.Password),
                                Role = request.Role

                            });


                            _context.SaveChanges();

                            return new Result()
                            {
                                IsSuccess = true,
                                Message = "ادمین جدید با موفقیت افزوده شد"
                            };
                        }

                        return new Result()
                        {
                            IsSuccess = false,
                            Message = "تکرار رمز عبور به درستی وارد نشده است"
                        };
                    }

                    return new Result()
                    {
                        IsSuccess = false,
                        Message = "طول رمز عبور باید بیش از 8 کاراکتر باشد"
                    };
                }

                return new Result()
                {
                    IsSuccess = false,
                    Message = "نام کاربری قبلا استقاده شده است"
                };

            }

            return new Result()
            {
                IsSuccess = false,
                Message = "طول نام کاربری باید بیش از 5 کاراکتر باشد"
            };
        }
    }
}
