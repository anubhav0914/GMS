using System;
using System.Threading.Tasks;
using System.Transactions;
using Abp.Application.Services;
using GroupManagementSystem.DTOS;
using GroupManagementSystem.Utis;

namespace GroupManagementSystem.Manager.Interfaces;

public interface ITransicationsAppService : IApplicationService
{
    Task<APIResponse<TransactionResponseDTO>> CreateTransaction(TransactionRequestDTO dto);
}
