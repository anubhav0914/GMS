using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GroupManagementSystem.DTOs;

namespace GroupManagementSystem.Managers.Interfaces;

public interface IGMSTransaction : IApplicationService
{
    public Task<GMSTransactionResponseDTO> AddCollection(TransactionResponseDTO dto, long paymentStructureId);
    
    public Task<PagedResultDto<CombinedTransactionDto>> GetCollectionTransactionsAsync(PagedTransactionFilterDto input);

}
