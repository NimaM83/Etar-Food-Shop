using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Admins.Table.Commands.UpdateTable
{
    public class UpdateTableSrvice : IUpdateTableService
    {
        private readonly IDataBaseContext _context;

        public UpdateTableSrvice(IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute (ReqUpdateTableDto request)
        {
            var foundedTable = _context.tables.Find(request.Id);

            if(foundedTable != null)
            {
                foundedTable.Number = request.Number;
                foundedTable.Capacity = request.Capacity;
                _context.SaveChanges();

                return new Result ()
                {
                    IsSuccess = true,
                    Message = "میز با موفقیت ویرایش شد"
                };
            }

            return new Result()
            {
                IsSuccess = false,
                Message = "میزی یافت نشد"
            };
        }
    }
}
