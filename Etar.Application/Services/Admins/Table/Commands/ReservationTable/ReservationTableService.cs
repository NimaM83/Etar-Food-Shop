using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Admins.Table.Commands.ReservationTable
{
    public class ReservationTableService : IReservationTableService
    {
        private readonly IDataBaseContext _context;

        public ReservationTableService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute (ReqReservationTableDto  request)
        {
            var foundedTable = _context.tables.Find(request.Id);

            if(foundedTable != null)
            {
                if(foundedTable.ReservedTime ==  null)
                {
                    foundedTable.ReservedTime = request.ReservationTime;
                    foundedTable.IsReserved = true;
                    _context.SaveChanges();

                    return new Result()
                    {
                        IsSuccess = true,
                        Message = "میز با موفقیت رزرو شد"
                    };
                }

                return new Result()
                {
                    IsSuccess = false,
                    Message = "میز قبلا رزرو  شده است"
                };

            }

            return new Result()
            {
                IsSuccess = false,
                Message = "میزی  یافت نشد"
            };
        }
    }
}
