﻿namespace Etar.Application.Services.Admins.Table.Commands.ReservationTable
{
    public class ReqReservationTableDto
    {
        public Guid Id { get; set; }
        public TimeOnly ReservationTime { get; set; }
    }
}
