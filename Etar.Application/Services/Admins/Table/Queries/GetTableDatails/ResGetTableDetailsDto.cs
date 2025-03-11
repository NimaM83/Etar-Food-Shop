namespace Etar.Application.Services.Admins.Table.Queries.GetTableDatails
{
    public class ResGetTableDetailsDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public string? ReservedTime { get; set; }
    }
}
