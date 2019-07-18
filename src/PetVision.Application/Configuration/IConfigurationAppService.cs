using System.Threading.Tasks;
using Abp.Application.Services;
using PetVision.Configuration.Dto;

namespace PetVision.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}