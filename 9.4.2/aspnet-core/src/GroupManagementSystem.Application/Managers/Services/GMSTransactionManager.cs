using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using GroupManagementSystem.DTOs;
using GroupManagementSystem.Managers.Interfaces;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.Managers.Services;

public class GMSTransactionManager : ApplicationService, IGMSTransaction
{
    private readonly IRepository<GMSTransaction, long> _gmsTransactionRepository;
    private readonly IRepository<Transaction, long> _transactionRepository;
    private readonly IRepository<GroupParticipant, long> _participantRepository;
    private readonly IRepository<PaymentStructure, long> _paymentStructureRepository;

    private readonly IMapper _mapper;

    public GMSTransactionManager(IRepository<GMSTransaction, long> gmsTransactionRepository,
     IMapper mapper,
     IRepository<Transaction, long> transactionRepository,
     IRepository<GroupParticipant, long> participantRepository,
     IRepository<PaymentStructure, long> paymentStructureRepository
     )
    {
        _gmsTransactionRepository = gmsTransactionRepository;
        _mapper = mapper;
        _transactionRepository = transactionRepository;
        _participantRepository = participantRepository;
        _paymentStructureRepository = paymentStructureRepository;
    }

    public async Task<GMSTransactionResponseDTO> AddCollection(TransactionResponseDTO dto, long paymentStructureId)
    {
        var gmsTransaction = new GMSTransaction
        {
            RefNo = dto.RefNo,
            Date = dto.Date,
            Amount = dto.Amount,
            TransId = dto.Id,
            PaymentStructureId = paymentStructureId,
            TransactionType = dto.Type,
            Mode = dto.Mode

        };

        var inserted = await _gmsTransactionRepository.InsertAsync(gmsTransaction);
        var resultDto = new GMSTransactionResponseDTO
        {
            Id = inserted.Id,
            RefNo = inserted.RefNo,
            Amount = inserted.Amount,
            Status = inserted.Status,
            Mode = inserted.Mode,
            Date = inserted.Date
        };
        return resultDto;
    }

    public async Task<PagedResultDto<CombinedTransactionDto>> GetCollectionTransactionsAsync(PagedTransactionFilterDto input)
    {
        // Get raw data from repositories
        var gmstransactions = await _gmsTransactionRepository.GetAllListAsync();
        var participants = await _participantRepository.GetAllListAsync();
        var paymentStructures = await _paymentStructureRepository.GetAllListAsync();

        // Perform in-memory joins
        var query = from g in gmstransactions
            join p in participants on g.RefNo equals p.RefNo
            join ps in paymentStructures on g.PaymentStructureId equals ps.Id
            select new CombinedTransactionDto
            {
                GmsTransactionId = g.Id,
                RefNo = g.RefNo,
                Date = g.Date,
                Amount = g.Amount,
                FeeStructure = ps.Name,
                ParticipantRefNo = p.RefNo,
                TransactionType = g.TransactionType,
                MemberType = p.MemberType,
                UserName = p.UserName,
                Email = p.Emial,
                PhoneNumber = p.PhoneNumber 
            };

                    // Apply filters
        if (!string.IsNullOrWhiteSpace(input.RefNo))
            query = query.Where(x => x.RefNo.Contains(input.RefNo));

        if (input.FromDate.HasValue)
            query = query.Where(x => x.Date >= input.FromDate.Value);

        if (input.ToDate.HasValue)
            query = query.Where(x => x.Date <= input.ToDate.Value);

        if (input.PaymentStructureId.HasValue)
        {
            var feeTypeName = paymentStructures.FirstOrDefault(ps => ps.Id == input.PaymentStructureId.Value)?.Name;
            if (!string.IsNullOrWhiteSpace(feeTypeName))
                query = query.Where(x => x.FeeStructure == feeTypeName);
        }

        if (input.MemberType.HasValue)
            query = query.Where(x => x.MemberType == input.MemberType.Value);
        if (input.TransactionType.HasValue)
            query = query.Where(x => x.TransactionType == input.TransactionType.Value);

        // Total count before pagination
        var totalCount = query.Count();

        // Apply pagination
        var items = query
            .OrderByDescending(x => x.Date)
            .Skip((input.PageNumber - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToList();

        return new PagedResultDto<CombinedTransactionDto>(totalCount, items);
    }
}

