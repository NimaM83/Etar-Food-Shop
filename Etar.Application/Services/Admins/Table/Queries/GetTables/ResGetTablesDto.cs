﻿namespace Etar.Application.Services.Admins.Table.Queries.GetTables
{
    public class ResGetTablesDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public string ReservedTime { get; set; }
        public bool IsReserved { get; set; }
    }
}
