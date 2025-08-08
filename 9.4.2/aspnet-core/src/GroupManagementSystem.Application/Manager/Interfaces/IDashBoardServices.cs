using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using GroupManagementSystem.DTOS;
using GroupManagementSystem.Utis;

namespace GroupManagementSystem.Manager.Interfaces;

public interface IDashBoardServices :IApplicationService
{
    public Task<APIResponse<SchoolDashBoardDTO>> GetSchoolDashBoard(long GroupId);
} 
