using Etar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Food.Queries.GetFoodDetail
{
    public interface IGetFoodDetaisService
    {
        Result<ResGetFoodDetailsDto> Execute(Guid id);
    }
}
