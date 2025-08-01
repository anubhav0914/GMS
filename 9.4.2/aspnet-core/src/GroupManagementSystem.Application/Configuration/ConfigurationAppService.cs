using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using GroupManagementSystem.Configuration.Dto;

namespace GroupManagementSystem.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : GroupManagementSystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
