namespace Etar.Application.Services.Admins.Cart.Queries.GetCartDetails
{
    public class CartDetailsDto
    {
        public string AdminName { get; set; }
        public List<CartDetilasItemDto> Items { get; set; }
        public double TotalPrice { get; set; }
    }
}
