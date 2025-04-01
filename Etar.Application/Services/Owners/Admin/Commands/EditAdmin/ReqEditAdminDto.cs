using Etar.Domain.Entities.Users;

namespace Etar.Application.Services.Owners.Admin.Commands.EditAdmin
{
    public class ReqEditAdminDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public EAdminRoles Role { get; set; }
    }
}
