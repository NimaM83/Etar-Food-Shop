namespace Etar.Application.Services.Admins.Food.Commands.AddFood
{
    public class ReqAddFoodDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
