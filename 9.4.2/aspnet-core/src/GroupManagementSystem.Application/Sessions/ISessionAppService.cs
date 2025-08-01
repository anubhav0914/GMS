using System.Threading.Tasks;
using Abp.Application.Services;
using GroupManagementSystem.Sessions.Dto;

namespace GroupManagementSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
