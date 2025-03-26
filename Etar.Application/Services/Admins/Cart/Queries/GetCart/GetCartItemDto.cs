namespace Etar.Application.Services.Admins.Cart.Queries.GetCart
{
    public class GetCartItemDto
    {
        public Guid Id { get; set; }
        public Guid FoodId { get; set; }
        public int count { get; set; }
        public double PriceForOne { get; set; }
        public double PriceForCount { get; set; }
    }
}
