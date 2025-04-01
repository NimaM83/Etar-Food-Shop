using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Etar.Application.Services.Owners.Admin.Queries.GetAdminOrders
{
    public class GetAdminOrdersService : IGetAdminOrdersService
    {
        private readonly IDataBaseContext _context;
        
        public GetAdminOrdersService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result<List<ResGetAdminOrdersDto>> Execute(Guid adminId)
        {
            var foundedOrders = _context.adminOrders.Include(o => o.Cart)
                                .Where(o => o.Cart.AdminId == adminId)
                                .ToList();

            if(foundedOrders.Any())
            {
                List<ResGetAdminOrdersDto> result = new List<ResGetAdminOrdersDto>();
                foreach(var  item  in foundedOrders)
                {
                    result.Add(new ResGetAdminOrdersDto()
                    {
                        Id = item.Id,
                        TotalPrice = item.TotalPrice,
                        RegisterTime = item.RegisterTime.ToShortTimeString(),
                    });

                }

                return new Result<List<ResGetAdminOrdersDto>>()
                {
                    Data = result,
                    IsSuccess = true,
                    Message = "سفارشات با موفقیت دریافت شدند"
                };
            }

            return new Result<List<ResGetAdminOrdersDto>>()
            {
                IsSuccess = false,
                Message = "این ادمین تا کنون سفارشی ثبت نکرده است"
            };
        }
    }

}
