namespace Etar.Application.Services.Owners.Order.Queries.GetOrders
{
    public class GetOrderItemsDto
    {
        public Guid Id { get; set; }
        public string RegisterTime { get; set; }
        public double TotalPrice { get; set; }
        public string AdminName { get; set; }
    }
}
