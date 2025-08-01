using System.Threading.Tasks;
using GroupManagementSystem.Configuration.Dto;

namespace GroupManagementSystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
