namespace Etar.Application.Services.Admins.Food.Queries.GetFoods
{
    public class ResGetFoodsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public Guid catId { get; set; }
        public double Price { get; set; }
        public int Inventory {  get; set; }
    }
}
