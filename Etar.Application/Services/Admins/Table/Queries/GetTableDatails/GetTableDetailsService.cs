using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Admins.Table.Queries.GetTableDatails
{
    public class GetTableDetailsService : IGetTableDetailsService
    {
        private readonly IDataBaseContext _context;

        public GetTableDetailsService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result<ResGetTableDetailsDto> Execute (Guid id)
        {
            var foundedTable = _context.tables.Find(id);

            if(foundedTable != null)
            {
                if(foundedTable.ReservedTime != null &&
                    (TimeOnly.FromDateTime(DateTime.Now) >= foundedTable.ReservedTime))
                {
                    foundedTable.ReservedTime = null;
                    foundedTable.IsReserved = false;
                    _context.SaveChanges();
                }

                TimeOnly temp = foundedTable.ReservedTime.Value;
                return new Result<ResGetTableDetailsDto>()
                {
                    IsSuccess = true,
                    Message = "اطلاعات میز با موفقیت دریافت شد",
                    Data =  new ResGetTableDetailsDto ()
                    {
                        Capacity = foundedTable.Capacity,
                        Number = foundedTable.Number,
                        ReservedTime = temp.ToString("HH:mm")
                    }
                };
            }

            return new Result<ResGetTableDetailsDto>()
            {
                Data = null,
                IsSuccess = false,
                Message = "میزی یافت نشد"
            };
        }
    }
}
