using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Admins.Table.Commands.RemoveTable
{
    public class RemoveTableService : IRemoveTableService
    {
        private readonly IDataBaseContext _context;

        public RemoveTableService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute(Guid tableId)
        {
            var foundedTable = _context.tables.Find(tableId);

            if(foundedTable != null)
            {
                _context.tables.Remove(foundedTable);
                _context.SaveChanges();

                return new Result()
                {
                    IsSuccess = true,
                    Message = "میز با موفقیت حذف شد"
                };
            }

            return new Result()
            {
                IsSuccess = false,
                Message = "میز یافت نشد"
            };
        }
    }
}
