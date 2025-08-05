using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GroupManagementSystem.DTOs;

namespace GroupManagementSystem.Managers.Interfaces;

public interface IGroupParticipant : IApplicationService
{
    public Task<PagedResultDto<GroupParticipantResponseDTO>> GetPaginatedAsync(PagedParticipantInputDto input);
    public Task<GroupParticipantResponseDTO> AddGroupMemebr(GroupParticipantRequestDTO dto);
    public Task<List<GroupParticipantResponseDTO>> ImportAddGroupMembers(List<GroupParticipantRequestDTO> dtos);

}
