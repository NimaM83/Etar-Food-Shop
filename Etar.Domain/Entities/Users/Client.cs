using Etar.Domain.Entities.Addresses;
using System.ComponentModel.DataAnnotations;

namespace Etar.Domain.Entities.Users
{
    public class Client : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
