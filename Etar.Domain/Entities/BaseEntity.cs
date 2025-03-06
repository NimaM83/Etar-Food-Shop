using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Domain.Entities
{
    public class BaseEntity
    {
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}
