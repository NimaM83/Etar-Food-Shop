using Etar.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Food.Queries.GetCategories
{
    public interface IGetCategoriesService
    {
        Result<ResGetCategoriesDto> Execute(Guid? Id);
    }
}
