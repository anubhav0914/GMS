using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using GroupManagementSystem.DTOs;
using GroupManagementSystem.Managers.Interfaces;
using GroupManagementSystem.Models;
using GroupManagementSystem.Utis;
using Microsoft.EntityFrameworkCore;

namespace GroupManagementSystem.Managers.Services
{
    public class PaymentStructureAppService : ApplicationService, IPaymentStructure
    {
        private readonly IRepository<PaymentStructure, long> _paymentStructureRepository;

        public PaymentStructureAppService(IRepository<PaymentStructure, long> paymentStructureRepository)
        {
            _paymentStructureRepository = paymentStructureRepository;
        }

        public async Task<APIResponse<List<PaymentStructureResponseDTO>>> GetAllFeeStructure()
        {
            var entities = await _paymentStructureRepository.GetAll()
                .Include(p => p.GroupType)
                .ToListAsync();

            var result = entities.Select(p => new PaymentStructureResponseDTO
            {
                Id = p.Id,
                GroupTypeId = p.GroupTypeId,
                Name = p.Name,
                Amount = p.Amount,
                GroupId = p.GroupId
            }).ToList();

            return new APIResponse<List<PaymentStructureResponseDTO>>(result, "Fee structure retrieved successfully.");
        }

        public async Task<APIResponse<PaymentStructureResponseDTO>> CreateFeeType(PaymentStructureRequestDTO dto)
        {
            var entity = new PaymentStructure
            {
                GroupTypeId = dto.GroupTypeId,
                Name = dto.Name,
                Amount = dto.Amount,
                GroupId = dto.GroupId
            };

            var inserted = await _paymentStructureRepository.InsertAsync(entity);

            var response = new PaymentStructureResponseDTO
            {
                Id = inserted.Id,
                GroupTypeId = inserted.GroupTypeId,
                Name = inserted.Name,
                Amount = inserted.Amount,
                GroupId = inserted.GroupId
            };

            return new APIResponse<PaymentStructureResponseDTO>(response, "Fee type created successfully.");
        }
    }
}
