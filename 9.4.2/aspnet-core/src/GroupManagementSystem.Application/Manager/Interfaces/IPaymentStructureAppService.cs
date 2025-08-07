using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using GroupManagementSystem.DTOS;
using GroupManagementSystem.Utis;

namespace GroupManagementSystem.Manager.Interfaces;

public interface IPaymentStructureAppService : IApplicationService
{
    Task<APIResponse<PaymentStructureResponseDTO>> CreatePaymentStructure(PaymentStructureRequestDTO dto);
    Task<APIResponse<List<PaymentStructureResponseDTO>>> GetAllPaymentStructure(long groupId);
    Task<APIResponse<bool>> Delete(long paymentStructureId);
    Task<APIResponse<PaymentStructureResponseDTO>> UpdatePaymentStructure(PaymentStructureRequestDTO dto);

    

}
