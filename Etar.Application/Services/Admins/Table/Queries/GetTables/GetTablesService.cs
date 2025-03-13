using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Admins.Table.Queries.GetTables
{
    public class GetTablesService : IGetTablesService
    {
        private readonly IDataBaseContext _context;

        public GetTablesService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result<List<ResGetTablesDto>> Execute ()
        {
            var  foundedTables = _context.tables.ToList ();

            if(foundedTables.Count() > 0)
            {
                List<ResGetTablesDto> tables = new List<ResGetTablesDto> ();
                DateTime temp;

                foreach(var item in foundedTables)
                {
                    if (item.ReservedTime != null &&
                       !(DateTime.Now <= item.ReservedTime))
                        {
                            item.ReservedTime = null;
                            item.IsReserved = false;
                            _context.SaveChanges();
                        }

                    temp = item.ReservedTime != null ? item.ReservedTime.Value: new DateTime(10);

                    tables.Add(new ResGetTablesDto()
                    {
                        Id = item.Id,
                        Number = item.Number,
                        Capacity = item.Capacity,
                        ReservedTime = (temp == new DateTime(10)) ? "بدون رزرو" : temp.ToShortTimeString()
                    });
                }

                return new Result<List<ResGetTablesDto>>()
                {
                    Data = tables,
                    IsSuccess = true,
                    Message = "میز ها با موفقیت دریافت شدند"
                };
            }

            return new Result<List<ResGetTablesDto>>()
            {
                Data = null,
                IsSuccess = false,
                Message = "میزی یافت نشد"
            };
        }
    }
}
