using Etar.Domain.Entities.Users;

namespace Etar.Application.Services.Admins.User.Queries.SignInAdmin
{
    public class ResSignInAdminDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public EAdminRoles Role { get; set; }
    }
}
