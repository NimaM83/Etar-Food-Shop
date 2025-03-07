using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Domain.Entities.Foods
{
    public class FoodCategory
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
