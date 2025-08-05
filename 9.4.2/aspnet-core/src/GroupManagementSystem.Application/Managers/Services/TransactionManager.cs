using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using Castle.Windsor.Installer;
using GroupManagementSystem.DTOs;
using GroupManagementSystem.Managers.Interfaces;
using GroupManagementSystem.Models;
using GroupManagementSystem.Utis;

namespace GroupManagementSystem.Managers.Services;

public class TransactionManager : ApplicationService , ITransaction
{
    private readonly IRepository<Transaction, long> _transactionRepository;
    private readonly IGMSTransaction _gmsTransactionManager;

    private readonly IMapper _mapper;

    public TransactionManager(IRepository<Transaction, long> transactionRepository, IMapper mapper, IGMSTransaction gmsTransactionManager)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
        _gmsTransactionManager = gmsTransactionManager;
    }

    public async Task<APIResponse<TransactionResponseDTO>> AddTransaction(TransactionRequestDTO dto, long paymentStructureId){
    try
    {
        // Manually map TransactionResponseDTO to Transaction
        var transaction = new Transaction
        {
            RefNo = dto.RefNo,
            Amount = dto.Amount,
            TransactionType = dto.Type,
            Status = dto.Status,
            Mode = dto.Mode,
            TenantId = dto.TenantId,
            GroupId = dto.GroupId,
            Date = DateTime.UtcNow // always set date here
        };

        // Insert to DB
        var inserted = await _transactionRepository.InsertAsync(transaction);
        await CurrentUnitOfWork.SaveChangesAsync();
        // Manually map back to DTO
        var resultDto = new TransactionResponseDTO
        {
            Id = inserted.Id,
            RefNo = inserted.RefNo,
            Amount = inserted.Amount,
            Status = inserted.Status,
            Type = inserted.TransactionType,
            Mode = inserted.Mode,
            TenantId = inserted.TenantId,
            GroupId = inserted.GroupId,
            Date = inserted.Date
        };

        await _gmsTransactionManager.AddCollection(resultDto, paymentStructureId);

        return new APIResponse<TransactionResponseDTO>(resultDto, "Transaction added successfully.");
    }
    catch (Exception ex)
    {
        return new APIResponse<TransactionResponseDTO>(null, "Error while adding transaction: " + ex.Message);
    }
}

}
