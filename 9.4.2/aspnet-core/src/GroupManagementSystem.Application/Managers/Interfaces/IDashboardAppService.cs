using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using GroupManagementSystem.DTOs;

namespace GroupManagementSystem.Managers.Interfaces;

public interface IDashboardAppService : IApplicationService
{
    Task<DashboardDto> GetAdminDashboardAsync();
}

