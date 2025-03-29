using Etar.Application.Interfaces.Context;
using Etar.Common;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Admins.User.Queries.SignInAdmin
{
    public class SignInAdminService : ISignInAdminService
    {
        private readonly IDataBaseContext _context;
        public SignInAdminService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result<ResSignInAdminDto> Execute (ReqSignInAdminDto request)
        {
            var foundedAdmin = _context.admins.Where(a => a.UserName.Equals(request.UserName)).FirstOrDefault();

            if(foundedAdmin != null)
            {
                PasswordHasher hasher = new PasswordHasher();
                if(hasher.VerifyPassword(foundedAdmin.Password,request.Password))
                {
                    return new Result<ResSignInAdminDto>()
                    {
                        IsSuccess = true,
                        Message = "ورود موفقیت آمیز بود",
                        Data = new ResSignInAdminDto()
                        {
                            Id = foundedAdmin.Id,
                            UserName = foundedAdmin.UserName,
                            Role =  foundedAdmin.Role
                        }
                    };
                }

                return new Result<ResSignInAdminDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "رمز عبور نادرست است"
                };
            }

            return new Result<ResSignInAdminDto>()
            {
                Data = null,
                IsSuccess = false,
                Message = "کاربری با این نام کاربری یافت نشد"
            };
        }
    }
}
