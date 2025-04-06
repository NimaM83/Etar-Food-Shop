namespace Etar.Application.Services.Owners.Order.Queries.GetOrderDetails
{
    public class OrderDetailsItemDto
    {
        public string FoodName { get; set; }
        public int Count { get; set; }
        public double PriceForOne { get; set; }
        public double PriceForCount { get; set; }
    }
}
