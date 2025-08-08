using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using GroupManagementSystem.DTOS;
using GroupManagementSystem.Models;
using GroupManagementSystem.Utis;

namespace GroupManagementSystem.Manager.Interfaces;

public interface IGMSTrasactionAppService : IApplicationService
{
    public Task<APIResponse<GMSTransactionResponseDTO>> AddGMSTransaction(TransactionResponseDTO dto);
    public Task<APIResponse<List<GMSTransactionResponseDTO>>> GetGMSTransaction(GMSTransactionFilterDTO dto);

    
}
