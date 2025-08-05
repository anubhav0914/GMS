using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using GroupManagementSystem.DTOs;
using GroupManagementSystem.Managers.Interfaces;
using GroupManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupManagementSystem.Managers.Services;

public class GroupParticipantAppService : ApplicationService, IGroupParticipant
{
    private readonly IRepository<GroupParticipant, long> _participantRepo;

    public GroupParticipantAppService(IRepository<GroupParticipant, long> participantRepo)
    {
        _participantRepo = participantRepo;
    }

    public async Task<PagedResultDto<GroupParticipantResponseDTO>> GetPaginatedAsync(PagedParticipantInputDto input)
    {
        var query = _participantRepo.GetAll();

        // Filter by MemberType if providedf
        if (input.MemberType.HasValue)
        {
            query = query.Where(p => p.MemberType == input.MemberType.Value);
        }

        var totalCount = await query.CountAsync();

        var items = await query
            .OrderByDescending(p => p.Id) // Optional: sort newest first
            .Skip((input.PageNumber - 1) * input.PageSize)
            .Take(input.PageSize)
            .Select(p => new GroupParticipantResponseDTO
            {
                Id = p.Id,
                RefNo = p.RefNo,
                MemberType = p.MemberType,
                UserName = p.UserName,
                Emial = p.Emial,
                PhoneNumber = p.PhoneNumber
            })
            .ToListAsync();

        return new PagedResultDto<GroupParticipantResponseDTO>(totalCount, items);
    }

    public async Task<GroupParticipantResponseDTO> AddGroupMemebr(GroupParticipantRequestDTO dto)
    {
        // 1. Get TenantId
        var tenantId = AbpSession.TenantId ?? 1; // fallback to 1 for dev/test

        // 2. Determine prefix
        string prefix = dto.MemberType switch
        {
            MemberType.Student => "ST",
            MemberType.Teacher => "TC",
            MemberType.Admin => "AD",
            MemberType.Farmer => "FR",
            MemberType.Father => "FA",
            _ => "UN" // Unknown
        };

        // 3. Count existing participants to generate sequence
        var existingCount = await _participantRepo
            .GetAll()
            .Where(p => p.TenantId == tenantId && p.GroupTypeId == dto.GroupTypeId && p.MemberType == dto.MemberType)
            .CountAsync();

        // 4. Generate RefNo → Format: ST-tenantId-groupTypeId-seq
        string refNo = $"{prefix}-{tenantId:D3}-{dto.GroupTypeId:D3}-{(existingCount + 1):D3}";

        // 5. Create entity
        var entity = new GroupParticipant
        {
            RefNo = refNo,
            MemberType = dto.MemberType,
            GroupTypeId = dto.GroupTypeId,
            UserName = dto.UserName,
            Emial = dto.Emial,
            PhoneNumber = dto.PhoneNumber,
            TenantId = tenantId
        };

        // 6. Save
        var inserted = await _participantRepo.InsertAsync(entity);

        // 7. Return response DTO
        return new GroupParticipantResponseDTO
        {
            Id = inserted.Id,
            RefNo = inserted.RefNo,
            MemberType = inserted.MemberType,
            GroupTypeId = inserted.GroupTypeId,
            UserName = inserted.UserName,
            Emial = inserted.Emial,
            PhoneNumber = inserted.PhoneNumber
        };
    }



public async Task<List<GroupParticipantResponseDTO>> ImportAddGroupMembers(List<GroupParticipantRequestDTO> dtos)
{
    var tenantId = AbpSession.TenantId ?? 1;

    var responseList = new List<GroupParticipantResponseDTO>();

    foreach (var dto in dtos)
    {
        // Prefix from MemberType
        string prefix = dto.MemberType switch
        {
            MemberType.Student => "ST",
            MemberType.Teacher => "TC",
            MemberType.Admin => "AD",
            MemberType.Farmer => "FR",
            MemberType.Father => "FA",
            _ => "UN"
        };

        // Count existing members with same type/group to generate sequence
        var existingCount = await _participantRepo
            .GetAll()
            .Where(p => p.TenantId == tenantId &&
                        p.GroupTypeId == dto.GroupTypeId &&
                        p.MemberType == dto.MemberType)
            .CountAsync();

        // Generate RefNo
        string refNo = $"{prefix}-{tenantId:D3}-{dto.GroupTypeId:D3}-{(existingCount + 1):D3}";

        // Create entity
        var entity = new GroupParticipant
        {
            RefNo = refNo,
            MemberType = dto.MemberType,
            GroupTypeId = dto.GroupTypeId,
            UserName = dto.UserName,
            Emial = dto.Emial,
            PhoneNumber = dto.PhoneNumber,
            TenantId = tenantId
        };

        // Save entity
        var inserted = await _participantRepo.InsertAsync(entity);
        await CurrentUnitOfWork.SaveChangesAsync();

        // Add to response
            responseList.Add(new GroupParticipantResponseDTO
        {
            Id = inserted.Id,
            RefNo = inserted.RefNo,
            MemberType = inserted.MemberType,
            GroupTypeId = inserted.GroupTypeId,
            UserName = inserted.UserName,
            Emial = inserted.Emial,
            PhoneNumber = inserted.PhoneNumber
        });
    }

    return responseList;
}

}

