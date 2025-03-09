namespace Etar.Application.Services.Admins.Food.Queries.GetFoods
{
    public class ResGetFoodDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
