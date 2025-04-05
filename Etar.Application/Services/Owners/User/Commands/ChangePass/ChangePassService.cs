using Etar.Application.Interfaces.Context;
using Etar.Common;
using Etar.Domain.Entities;
using Etar.Domain.Entities.Users;

namespace Etar.Application.Services.Owners.User.Commands.ChangePass
{
    public class ChangePassService : IChangePassService
    {
        private readonly IDataBaseContext _context;
        public ChangePassService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute (ReqChangePassDto request)
        {
            var foundedUser = _context.admins.Where(u => u.Role == EAdminRoles.Owner && u.Id == request.OwnerId)
                              .FirstOrDefault();

            if(foundedUser != null)
            {
                PasswordHasher hasher = new PasswordHasher();
                if(hasher.VerifyPassword(foundedUser.Password, request.OldPassword))
                {
                    if(request.NewPassword.Length >= 8)
                    {
                        if(request.NewPassword.Equals(request.RePassword))
                        {
                            foundedUser.Password = hasher.HashPassword(request.NewPassword);
                            _context.SaveChanges();
                        }
                    }

                    return new Result()
                    {
                        IsSuccess = false,
                        Message = "طول رمز عبور باید حداقل 8 کارکتر باشد"
                    };
                }

                return new Result()
                {
                    IsSuccess = false,
                    Message = "رمز عبور قدیمی به درستی وارد نشده است"
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
