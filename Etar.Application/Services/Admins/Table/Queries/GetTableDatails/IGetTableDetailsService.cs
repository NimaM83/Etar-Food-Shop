using Etar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Table.Queries.GetTableDatails
{
    public interface IGetTableDetailsService
    {
        Result<ResGetTableDetailsDto> Execute(Guid id);
    }
}
