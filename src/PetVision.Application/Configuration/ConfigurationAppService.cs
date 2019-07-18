using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using PetVision.Configuration.Dto;

namespace PetVision.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : PetVisionAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
