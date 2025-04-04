namespace Etar.Application.Services.Owners.Admin.Queries.GetAdminOrderDetails
{
    public class OrderDetailsItemDto
    {
        public string FoodName { get; set; }
        public int Count { get; set; }
        public double PriceForOne { get; set; }
        public double PriceForCount { get; set; }
    }
}
