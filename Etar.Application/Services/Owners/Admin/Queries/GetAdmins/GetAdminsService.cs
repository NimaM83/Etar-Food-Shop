using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Owners.Admin.Queries.GetAdmins
{
    public class GetAdminsService : IGetAdminsService
    {
        private readonly IDataBaseContext _context;

        public GetAdminsService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result<List<ResAllAdminsDto>> Execute()
        {
            var foundedAdmins = _context.admins.ToList();

            if (foundedAdmins.Count() > 0)
            {
                List<ResAllAdminsDto> admins = new List<ResAllAdminsDto>();
                foreach (var item in foundedAdmins)
                {
                    admins.Add(new ResAllAdminsDto()
                    {
                        Id = item.Id,
                        UserName = item.UserName,
                        RoleString = (item.Role == 0) ? "ادمین" : "مدیر",
                        Role = item.Role
                    });
                }

                return new Result<List<ResAllAdminsDto>>()
                {
                    IsSuccess = true,
                    Data = admins,
                    Message = "لیست ادمین ها با  موفقیت دریافت شد"
                };
            }

            return new Result<List<ResAllAdminsDto>>()
            {
                IsSuccess = false,
                Data = null,
                Message = "ادمینی جهت نمایش وحود ندارد"
            };

        }
    }
}
