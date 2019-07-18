using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PetVision.MultiTenancy.Dto;

namespace PetVision.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
