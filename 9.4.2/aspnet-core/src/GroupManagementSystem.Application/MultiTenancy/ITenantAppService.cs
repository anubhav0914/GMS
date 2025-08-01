using Abp.Application.Services;
using GroupManagementSystem.MultiTenancy.Dto;

namespace GroupManagementSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

