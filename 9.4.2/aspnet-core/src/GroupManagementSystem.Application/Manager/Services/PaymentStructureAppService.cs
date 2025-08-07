using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using GroupManagementSystem.DTOS;
using GroupManagementSystem.Models;
using GroupManagementSystem.Utis;
using GroupManagementSystem.Manager.Interfaces;
using Abp.UI;
using Abp.Authorization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GroupManagementSystem.Manager.Services
{
    [AbpAuthorize]
    public class PaymentStructureAppService : ApplicationService, IPaymentStructureAppService
    {
        private readonly IRepository<PaymentStructure, long> _paymentStructureRepository;
        private readonly IRepository<GroupDetails, long> _groupDetailsRepository;

        private readonly IMapper _mapper;

        public PaymentStructureAppService(
            IRepository<PaymentStructure, long> paymentStructureRepository,
            IRepository<GroupDetails, long> groupDetailsRepository,
            IMapper mapper)
        {
            _paymentStructureRepository = paymentStructureRepository;
            _mapper = mapper;
            _groupDetailsRepository = groupDetailsRepository;
        }

        public async Task<APIResponse<PaymentStructureResponseDTO>> CreatePaymentStructure(PaymentStructureRequestDTO dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.Amount) || dto.GroupId <= 0)
                {
                    return new APIResponse<PaymentStructureResponseDTO>
                    {
                        message = "Invalid input data.",
                        result = null
                    };
                }

                var entity = _mapper.Map<PaymentStructure>(dto);
                entity.TenantId = AbpSession.TenantId ?? throw new UserFriendlyException("Tenant not found.");

                var inserted = await _paymentStructureRepository.InsertAsync(entity);
                await CurrentUnitOfWork.SaveChangesAsync();

                var resultDto = _mapper.Map<PaymentStructureResponseDTO>(inserted);

                return new APIResponse<PaymentStructureResponseDTO>
                {
                    result = resultDto,
                    message = "Payment structure created successfully.",
                };
            }
            catch (Exception ex)
            {
                return new APIResponse<PaymentStructureResponseDTO>
                {
                    message = $"Error: {ex.Message}",
                    result = null
                };
            }
        }



        public async Task<APIResponse<List<PaymentStructureResponseDTO>>> GetAllPaymentStructure(long groupId)
        {
            try
            {
                var isExist = await _groupDetailsRepository.FirstOrDefaultAsync(gi => gi.Id == groupId);
                if (groupId <= 0 || isExist == null)
                {
                    return new APIResponse<List<PaymentStructureResponseDTO>>
                    {
                        message = "Invalid group ID. Or group ID does not exsit",
                        result = null
                    };
                }

                var tenantId = AbpSession.TenantId ?? throw new UserFriendlyException("Tenant not found.");

                var structures = await _paymentStructureRepository
                    .GetAllListAsync(x => x.GroupId == groupId && x.TenantId == tenantId);

                if (structures == null || structures.Count == 0)
                {
                    return new APIResponse<List<PaymentStructureResponseDTO>>
                    {
                        message = "No data found with this GroupID",
                        result = null
                    };
                }

                var result = _mapper.Map<List<PaymentStructureResponseDTO>>(structures);

                return new APIResponse<List<PaymentStructureResponseDTO>>
                {
                    result = result,
                    message = "Payment structures fetched successfully.",
                };
            }
            catch (Exception ex)
            {
                return new APIResponse<List<PaymentStructureResponseDTO>>
                {
                    message = $"Error: {ex.Message}",
                    result = null
                };
            }
        }





        public Task<APIResponse<PaymentStructureResponseDTO>> UpdatePaymentStructure(PaymentStructureRequestDTO dto)
        {
            throw new NotImplementedException();
        }
        public Task<APIResponse<bool>> Delete(long paymentStructureId)
        {
            throw new NotImplementedException();
        }
    }
}