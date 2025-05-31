using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Domain.Entities.Table
{
    public class Table
    {
        [Key]
        public Guid Id { get; set; }

        public int Number {  get; set; }
        public int Capacity { get; set; }
        public bool IsReserved { get; set; }
        public TimeOnly? ReservedTime { get; set; }
    }
}
