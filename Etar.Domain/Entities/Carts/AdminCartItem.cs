using Etar.Domain.Entities.Foods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Domain.Entities.Carts
{
    public class AdminCartItem
    {
        [Key]
        public Guid Id { get; set; }

        public virtual AdminCart Cart { get; set; }
        public Guid CartId { get; set; }

        public virtual Food Food { get; set; }
        public Guid FoodId { get; set; }

        public int count { get; set; }
        public double PriceForOne { get; set; }
        public double PriceForCount { get; set; }
    }
}
