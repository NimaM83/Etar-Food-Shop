namespace Etar.Application.Services.Owners.Order.Queries.GetOrderDetails
{
    public class ResOrderDetailsDto
    {
        public double TotalPrice { get; set; }
        public string RegisterTime { get; set; }
        public string AdminName { get; set; }
        public List<OrderDetailsItemDto> Items { get; set; }
    }
}
