using Etar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Food.Commands.AddCategory
{
    public interface IAddNewCategoryService
    {
        Result Execute(string name);
    }
}
