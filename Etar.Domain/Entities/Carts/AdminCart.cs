
using Etar.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Domain.Entities.Carts
{
    public class AdminCart
    {
        [Key]
        public Guid Id { get; set; }

        public virtual Admin Admin {  get; set; }
        public Guid AdminId { get; set; }

        public ICollection<AdminCartItem> Items { get; set; }

        public double TotalPrice { get; set; }
    }
}
