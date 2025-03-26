namespace Etar.Application.Services.Admins.Cart.Queries.GetCart
{
    public class ResGetCartDto
    {
        public Guid Id { get; set; }
        
        public List<GetCartItemDto> Items { get; set; }

        public double TotalPrice { get; set; }
    }
}
