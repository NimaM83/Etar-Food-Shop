using Etar.Domain.Entities;

namespace Etar.Application.Services.Owners.Admin.Commands.RemoveAdmin
{
    public interface IRemoveAdminService
    {
        Result Execute(Guid Id);
    }
}
