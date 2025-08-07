using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Abp.Application.Services;
using GroupManagementSystem.DTOS;
using GroupManagementSystem.Utis;

namespace GroupManagementSystem.Manager.Interfaces;

public interface IGroupDetailsAppService :IApplicationService
{
    Task<APIResponse<GroupDetailsResponseDTO>> CreateGroup(GroupDetailsRequestDTO dto);
    Task<APIResponse<List<GroupDetailsResponseDTO>>> GetAllGroups(); 

}
