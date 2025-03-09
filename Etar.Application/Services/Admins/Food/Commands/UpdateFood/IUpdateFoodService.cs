using Etar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Food.Commands.UpdateFood
{
    public interface IUpdateFoodService
    {
        Result Execute(ReqUpdateFoodDto request);
    }
}
