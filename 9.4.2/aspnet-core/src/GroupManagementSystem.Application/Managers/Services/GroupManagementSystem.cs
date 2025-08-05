using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using GroupManagementSystem.DTOs;
using GroupManagementSystem.Managers.Interfaces;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.Managers.Services;

public class GroupTypeAppService : ApplicationService, IGroupType
{
    private readonly IRepository<GroupType, long> _groupTypeRepository;

    public GroupTypeAppService(IRepository<GroupType, long> groupTypeRepository)
    {
        _groupTypeRepository = groupTypeRepository;
    }

    public async Task<GroupTypeResponseDTO> AddGroupType(GroupTypeRequestDTO dto)
    {
        var groupType = new GroupType
        {
            Name = dto.Name,
            Description = dto.Description
        };

        var result = await _groupTypeRepository.InsertAsync(groupType);

        return new GroupTypeResponseDTO
        {
            Id = result.Id,
            Name = result.Name,
            Description = result.Description
        };
    }


    public async Task<List<GroupTypeResponseDTO>> GetAllGroupTypes()
    {
        var groupTypes = await _groupTypeRepository.GetAllListAsync();

        var result = groupTypes.Select(gt => new GroupTypeResponseDTO
        {
            Id = gt.Id,
            Name = gt.Name,
            Description = gt.Description
        }).ToList();

        return result;
    }

}
