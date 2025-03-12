using Etar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Table.Commands.ReservationTable
{
    public interface IReservationTableService
    {
        Result Execute(ReqReservationTableDto request);
    }
}
