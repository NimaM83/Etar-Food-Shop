using Etar.Domain.Entities.Carts;
using Etar.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Domain.Entities.Orders
{
    public class AdminOrder
    {
        public Guid Id { get; set; }

        public virtual AdminCart Cart { get; set; }
        public Guid CartId { get; set; }

        public virtual Admin Admin { get; set; }
        public Guid AdminId { get; set; }

        public double TotalPrice { get; set; }
        public DateTime RegisterTime { get; set; }

    }
}
