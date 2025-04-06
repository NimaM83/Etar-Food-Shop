namespace Etar.Application.Services.Owners.Order.Queries.GetOrders
{
    public class ResGetOrdersDto
    {
        public string FiltredBy { get; set; }
        public double PriceByFilter { get; set; }
        public List<GetOrderItemsDto> Items { get; set; }
    }
}
