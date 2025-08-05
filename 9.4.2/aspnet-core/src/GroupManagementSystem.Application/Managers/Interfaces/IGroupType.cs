using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using GroupManagementSystem.DTOs;

namespace GroupManagementSystem.Managers.Interfaces;

public interface IGroupType : IApplicationService
{
    public Task<GroupTypeResponseDTO> AddGroupType(GroupTypeRequestDTO dto);
    public  Task<List<GroupTypeResponseDTO>> GetAllGroupTypes();

}
