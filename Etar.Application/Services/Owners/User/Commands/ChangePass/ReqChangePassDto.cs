namespace Etar.Application.Services.Owners.User.Commands.ChangePass
{
    public class ReqChangePassDto
    {
        public Guid OwnerId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string RePassword { get; set; }
    }
}
