using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Orm;
using Abp.Runtime.Session;
using AutoMapper;
using GroupManagementSystem.DTOS;
using GroupManagementSystem.Manager.Interfaces;
using GroupManagementSystem.Models;
using GroupManagementSystem.Utis;
using Microsoft.EntityFrameworkCore;

namespace GroupManagementSystem.Manager.Implementations
{
    public class GroupDetailsAppService : GroupManagementSystemAppServiceBase, IGroupDetailsAppService
    {
        private readonly IRepository<GroupDetails, long> _groupDetailsRepository;
        private readonly IMapper _mapper;
        private readonly IAbpSession _abpSession;

        public GroupDetailsAppService(
            IRepository<GroupDetails, long> groupDetailsRepository,
            IMapper mapper,
            IAbpSession abpSession)
        {
            _groupDetailsRepository = groupDetailsRepository;
            _mapper = mapper;
            _abpSession = abpSession;
        }

        public async Task<APIResponse<GroupDetailsResponseDTO>> CreateGroup(GroupDetailsRequestDTO dto)
        {
            try
            {
                var isExistName = await _groupDetailsRepository.FirstOrDefaultAsync(gd => gd.GroupName == dto.GroupName);

                if (isExistName != null)
                {
                    return new APIResponse<GroupDetailsResponseDTO>
                    {
                        message = "THE GroupName is already exist plsease choose another one ",
                        result = null
                    };
                }

                var groupEntity = _mapper.Map<GroupDetails>(dto);
                groupEntity.TenantId = _abpSession.TenantId ?? 1; // fallback if TenantId is null
                groupEntity.UserId = _abpSession?.UserId ?? 0;

                var insertedGroup = await _groupDetailsRepository.InsertAsync(groupEntity);

                var resultDto = _mapper.Map<GroupDetailsResponseDTO>(insertedGroup);

                return new APIResponse<GroupDetailsResponseDTO>
                {
                    message = "Group Created Successfully",
                    result = resultDto
                };
            }
            catch (Exception ex)
            {
                return new APIResponse<GroupDetailsResponseDTO>
                {
                    message = "Group Creation failed " + ex.Message,
                    result = null
                };
            }
        }


        public async Task<APIResponse<List<GroupDetailsResponseDTO>>> GetAllGroups()
        {
            try
            {
                var groups = await _groupDetailsRepository.GetAll().ToListAsync();

                if (groups == null || groups.Count == 0)
                {
                    return new APIResponse<List<GroupDetailsResponseDTO>>
                    {
                        message = "No Groups Found ",
                        result = null
                    };
                }

                var responseDto = _mapper.Map<List<GroupDetailsResponseDTO>>(groups);
                return new APIResponse<List<GroupDetailsResponseDTO>>
                    {
                        message = " Groups Date Fetched Sucessfully ",
                        result = responseDto
                    };

            }
            catch (System.Exception ex)
            {

                return new APIResponse<List<GroupDetailsResponseDTO>>
                    {
                        message = "Groups data failed to fetech  " + ex.Message ,
                        result = null
                    };;
            }
        }

        

       
    }
}
