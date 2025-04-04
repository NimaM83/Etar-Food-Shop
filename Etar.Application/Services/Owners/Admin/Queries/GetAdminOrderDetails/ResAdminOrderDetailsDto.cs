namespace Etar.Application.Services.Owners.Admin.Queries.GetAdminOrderDetails
{
    public class ResAdminOrderDetailsDto
    {
        public double TotalPrice { get; set; }
        public string RegisterTime { get; set; }
        public string AdminName { get; set; }
        public List<OrderDetailsItemDto> Items { get; set; }
    }
}
