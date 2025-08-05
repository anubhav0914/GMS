using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using GroupManagementSystem.DTOs;
using GroupManagementSystem.Utis;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GroupManagementSystem.Managers.Interfaces;

public interface ITransaction : IApplicationService
{
    public Task<APIResponse<TransactionResponseDTO>> AddTransaction(TransactionRequestDTO dto, long paymentStructureId);
}
