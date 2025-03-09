namespace Etar.Application.Services.Admins.Food.Commands.UpdateFood
{
    public class ReqUpdateFoodDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public double Price { get; set; }
    }
}
