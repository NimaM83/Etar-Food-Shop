using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;

namespace Etar.Application.Services.Admins.Food.Commands.UpdateInvenroy
{
    public class UpdateInventoryService : IUpdateInventoryService
    {
        private readonly IDataBaseContext _context;
        public UpdateInventoryService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute(Guid id, int editAmount)
        {
            var foundedFood = _context.foods.Find(id);

            if (foundedFood != null)
            { 
                if( editAmount > 0 ||
                    (editAmount < 0 && foundedFood.Inventory >= -editAmount))
                {
                    foundedFood.Inventory += editAmount;
                    _context.SaveChanges();

                    return new Result()
                    {
                        IsSuccess = true,
                    };
                }

              
                return new Result()
                {
                    IsSuccess = false,
                    Message = "مقدار درخواستی بیش از موجودی غذا میباشد"
                };
            }

            return new Result()
            {
                IsSuccess = false,
                Message = "غذایی یافت نشد"
            };
        
        }
    }
}
