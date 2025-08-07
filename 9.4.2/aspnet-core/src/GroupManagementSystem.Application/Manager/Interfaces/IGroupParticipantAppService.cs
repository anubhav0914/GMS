using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using GroupManagementSystem.DTOS;
using GroupManagementSystem.Utis;
using Microsoft.AspNetCore.Mvc;

namespace GroupManagementSystem.Manager.Interfaces;

public interface IGroupParticipantAppService : IApplicationService
{
    Task<APIResponse<GroupParticipantResponseDTO>> CreateGroupParticipant([FromForm] GroupParticipantRequestDTO dto);
    Task<APIResponse<List<GroupParticipantResponseDTO>>> ImportParticipant(List<GroupParticipantRequestDTO> dto);
    Task<APIResponse<List<GroupParticipantResponseDTO>>> GetParticipants(GroupParticipantsDTO dto);
    
    Task<APIResponse<List<GroupParticipantResponseDTO>>> UpdateParticipants(GroupParticipantsUpdateDTO dto);
    Task<APIResponse<List<GroupParticipantResponseDTO>>> DeleteParticipants(long membId);

    
}
