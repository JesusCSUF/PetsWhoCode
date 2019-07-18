using System.Threading.Tasks;
using Abp.Application.Services;
using PetVision.Authorization.Accounts.Dto;

namespace PetVision.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
