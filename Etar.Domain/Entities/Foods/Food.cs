using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Domain.Entities.Foods
{
    public class Food : BaseEntity  
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Inventory { get; set; }
        public  double Price { get; set; }

        public virtual FoodCategory Category { get; set; }
        public Guid CatId { get; set; }
    
    }
}
