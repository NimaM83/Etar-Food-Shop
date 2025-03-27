using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Domain.Entities.Orders
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
        public double TotalPrice { get; set; }
        public EOrderUser User { get; set; }

    }
}
