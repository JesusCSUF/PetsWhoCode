using System.Threading.Tasks;
using Abp.Application.Services;
using PetVision.Sessions.Dto;

namespace PetVision.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
