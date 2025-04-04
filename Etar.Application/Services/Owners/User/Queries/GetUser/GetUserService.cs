using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;
using Etar.Domain.Entities.Users;

namespace Etar.Application.Services.Owners.User.Queries.GetUser
{
    public class GetUserService : IGetUserService
    {
        private readonly IDataBaseContext _context;
        public GetUserService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result<ResGetUserDto> Execute(Guid Id)
        {
            var foundedUser = _context.admins.Find(Id);
            
            if(foundedUser != null)
            {
                ResGetUserDto result = new ResGetUserDto()
                {
                    Id = Id,
                    UserName = foundedUser.UserName,
                    Role = foundedUser.Role == EAdminRoles.Owner ? "مدیر" : "ادمین"
                };

                return new Result<ResGetUserDto>()
                {
                    Data = result,
                    IsSuccess = true,
                    Message = "کاربر با موفقیت دریافت شد"
                };
            }

            return new Result<ResGetUserDto>()
            {
                IsSuccess = false,
                Message = "حساب کاربری یافت نشد"
            };
        }
    }
}
