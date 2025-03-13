using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Admins.Table.Commands.AddTable
{
    public class AddTableService : IAddTableService
    {
        private readonly IDataBaseContext _context;

        public AddTableService(IDataBaseContext context)
        { 
            _context = context;
        }

        public Result Execute(ReqAddTableDto request)
        {
            bool isValid = _context.tables.Where(t => t.Number == request.Number)
                           .ToList().Count() == 0? true:false;

            if(isValid)
            {
                _context.tables.Add(new Domain.Entities.Table.Table()
                {
                    Number = request.Number,
                    Capacity = request.Capacity,
                });
                _context.SaveChanges();

                return new Result()
                {
                    IsSuccess = true,
                    Message = "میز با موفقیت افزوده شد"
                };
            }

            return new Result()
            {
                IsSuccess = false,
                Message = "میزی با این شماره قبلا ایجاد شده است"
            };
        }
    }
}
