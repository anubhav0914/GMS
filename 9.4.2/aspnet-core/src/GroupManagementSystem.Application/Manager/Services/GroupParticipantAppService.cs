using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using GroupManagementSystem.DTOS;
using GroupManagementSystem.Models;
using GroupManagementSystem.Utis;
using GroupManagementSystem.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Abp.Domain.Uow;
using Microsoft.AspNetCore.Mvc;

namespace GroupManagementSystem.Manager.Services
{
    public class GroupParticipantAppService : ApplicationService, IGroupParticipantAppService
    {
        private readonly IRepository<GroupParticipant, long> _groupParticipantRepository;
        private readonly IRepository<GroupDetails, long> _groupDetailsRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        private readonly IMapper _mapper;

        public GroupParticipantAppService(
            IRepository<GroupParticipant, long> groupParticipantRepository,
            IRepository<GroupDetails, long> groupDetailsRepository,
                    IUnitOfWorkManager unitOfWorkManager,

            IMapper mapper)
        {
            _groupParticipantRepository = groupParticipantRepository;
            _groupDetailsRepository = groupDetailsRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _mapper = mapper;
        }

        public async Task<APIResponse<GroupParticipantResponseDTO>> CreateGroupParticipant([FromForm] GroupParticipantRequestDTO dto)
        {
            try
            {
                // Check if group exists
                var group = await _groupDetailsRepository.FirstOrDefaultAsync(dto.GroupId);
                if (group == null)
                {
                    return new APIResponse<GroupParticipantResponseDTO>
                    {
                        message = "Group not found",
                        result = null
                    };
                }

                var isExistEmail = await _groupParticipantRepository.FirstOrDefaultAsync(g => g.Email == dto.Email);
                if (isExistEmail != null)
                {
                    return new APIResponse<GroupParticipantResponseDTO>
                    {
                        message = "The Email alredy exist with this email",
                        result = null
                    };
                }

                // Count existing participants in group
                var count = await _groupParticipantRepository
                    .GetAll()
                    .Where(x => x.GroupId == dto.GroupId && x.TenantId == AbpSession.TenantId)
                    .CountAsync();

                string tenantCode = AbpSession.TenantId?.ToString("D3") ?? "000";
                string groupCode = dto.GroupId.ToString("D3");
                string sequenceCode = (count + 1).ToString("D3");
                string groupMemberRefNo = $"{GetPrefix(dto.MemberType)}{tenantCode}{groupCode}{sequenceCode}";

                // Create entity
                // var entity = new GroupParticipant
                // {
                //     GroupId = dto.GroupId,
                //     UserName = dto.UserName,
                //     Email = dto.Email,
                //     PhoneNumber = dto.PhoneNumber,
                //     MemberType = dto.MemberType,
                //     GroupMemberRefNO = groupMemberRefNo,
                //     TenantId = AbpSession.TenantId ?? 1 
                // };
                var entity = _mapper.Map<GroupParticipant>(dto);
                entity.TenantId = AbpSession.TenantId ?? 1;
                entity.GroupMemberRefNO = groupMemberRefNo;

                await _groupParticipantRepository.InsertAsync(entity);

                // maping to response Dto
                var responseDto = _mapper.Map<GroupParticipantResponseDTO>(entity);

                return new APIResponse<GroupParticipantResponseDTO>
                {
                    message = "Participant created successfully",
                    result = responseDto
                };
            }
            catch (Exception ex)
            {
                return new APIResponse<GroupParticipantResponseDTO>
                {
                    message = $"Error: {ex.Message}",
                    result = null
                };
            }
        }

        public async Task<APIResponse<List<GroupParticipantResponseDTO>>> ImportParticipant(List<GroupParticipantRequestDTO> dtoList)
        {
            var responseList = new List<GroupParticipantResponseDTO>();
            var tenantId = AbpSession.TenantId ?? 1;

            foreach (var dto in dtoList)
            {
                // chck if group exists
                var groupExists = await _groupDetailsRepository.GetAll().AnyAsync(g => g.Id == dto.GroupId);
                if (!groupExists)
                {
                    return new APIResponse<List<GroupParticipantResponseDTO>>
                    {
                        message = $"Group with ID {dto.GroupId} not found.",
                        result = null
                    };
                }
                var isExistEmail = await _groupParticipantRepository.FirstOrDefaultAsync(g => g.Email == dto.Email);
                if (isExistEmail != null)
                {
                    return new APIResponse<List<GroupParticipantResponseDTO>>
                    {
                        message = "The Email alredy exist with this email",
                        result = null
                    };
                }
                // count existing partcipants for sequence to ge the exact number to genrate the refno 
                var participantCount = await _groupParticipantRepository.GetAll()
                    .Where(x => x.GroupId == dto.GroupId && x.MemberType == dto.MemberType)
                    .CountAsync();

                var sequenceNo = (participantCount + 1).ToString("D3");
                var groupIdFormatted = dto.GroupId.ToString("D3");
                var tenantIdFormatted = tenantId.ToString("D3");

                var groupRefNo = $"{dto.MemberType.ToString().Substring(0, 3).ToUpper()}{tenantIdFormatted}{groupIdFormatted}{sequenceNo}";

                var entity = _mapper.Map<GroupParticipant>(dto);
                entity.GroupMemberRefNO = groupRefNo;
                entity.TenantId = tenantId;



                await _groupParticipantRepository.InsertAsync(entity);
                CurrentUnitOfWork.SaveChanges();
                await _unitOfWorkManager.Current.SaveChangesAsync();
                var resultDto = _mapper.Map<GroupParticipantResponseDTO>(entity);
                resultDto.GroupMemberRefNO = groupRefNo;
                resultDto.Id = entity.Id;

                responseList.Add(resultDto);
            }


            return new APIResponse<List<GroupParticipantResponseDTO>>
            {
                message = "Participants imported successfully",
                result = responseList,
            };
        }

        public async Task<APIResponse<List<GroupParticipantResponseDTO>>> GetParticipants(GroupParticipantsDTO dto)
        {


            try
            {
                var isGroupExist = await _groupDetailsRepository.FirstOrDefaultAsync(g => g.Id == dto.GroupId);

                if (isGroupExist == null)
                {
                     return new APIResponse<List<GroupParticipantResponseDTO>>
                    {
                        message = $"No Group Found with Group Id  {dto.GroupId}.",
                        result = null
                    };
                }
                var query = _groupParticipantRepository.GetAll()
                         .Where(g => g.GroupId == dto.GroupId);
    
                if (dto.MemberType != null)
                {
                    query = query.Where(g => g.MemberType == dto.MemberType);
                }
    
                var participants = await query.ToListAsync();
    
    
                if (participants == null || participants.Count == 0)
                {
                    return new APIResponse<List<GroupParticipantResponseDTO>>
                    {
                        message = "No participants found.",
                        result = null
                    };
                }
    
                var result = _mapper.Map<List<GroupParticipantResponseDTO>>(participants);
    
                return new APIResponse<List<GroupParticipantResponseDTO>>
                {
                    message = "Participants fetched successfully.",
                    result = result
                };
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        private string GetPrefix(MemberType type)
        {
            return type switch
            {
                MemberType.Student => "STU",
                MemberType.Teacher => "TCR",
                MemberType.Farmer => "FRM",
                MemberType.Father => "FTR",
                _ => "GEN"
            };
        }

        public Task<APIResponse<List<GroupParticipantResponseDTO>>> UpdateParticipants(GroupParticipantsUpdateDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<List<GroupParticipantResponseDTO>>> DeleteParticipants(long membId)
        {
            throw new NotImplementedException();
        }
    }
}
