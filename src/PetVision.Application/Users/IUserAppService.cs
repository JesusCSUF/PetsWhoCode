using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PetVision.Roles.Dto;
using PetVision.Users.Dto;

namespace PetVision.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}