using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using GroupManagementSystem.DTOs;
using GroupManagementSystem.Utis;

namespace GroupManagementSystem.Managers.Interfaces;

public interface IPaymentStructure : IApplicationService
{
   public Task<APIResponse<PaymentStructureResponseDTO>> CreateFeeType(PaymentStructureRequestDTO dto);
   public Task<APIResponse<List<PaymentStructureResponseDTO>>> GetAllFeeStructure();
}
