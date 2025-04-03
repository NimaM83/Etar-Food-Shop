using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;
using Etar.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Owners.Admin.Queries.GetAdmin
{
    public interface IGetAdminService
    {
        Result<ResGetAdminDto> Execute(Guid Id);
    }

    public class GetAdminService : IGetAdminService
    {
        private readonly IDataBaseContext _context;
        public GetAdminService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result<ResGetAdminDto> Execute (Guid Id)
        {
            var foundedAdmin = _context.admins.Find(Id);

            if(foundedAdmin != null)
            {
                return new Result<ResGetAdminDto>()
                {
                    Data = new ResGetAdminDto()
                    {
                        Id = foundedAdmin.Id,
                        UserName = foundedAdmin.UserName,
                        Role = foundedAdmin.Role,
                    },

                    IsSuccess  = true,
                    Message = "ادمین با موفقیت پیدا شد"
                }; 
            }

            return new Result<ResGetAdminDto>()
            {
                IsSuccess = false,
                Message = "ادمینی یافت نشد"
            };
        }
    }

    public class ResGetAdminDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public EAdminRoles Role { get; set; }
    }
}
