using Etar.Domain.Entities.Users;

namespace Etar.Application.Services.Owners.Admin.Queries.GetAdmins
{
    public class ResAllAdminsDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string RoleString { get; set; }
        public EAdminRoles Role { get; set; }
    }
}
