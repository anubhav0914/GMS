using System;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using AutoMapper;
using GroupManagementSystem.DTOS;
using GroupManagementSystem.Manager.Interfaces;
using GroupManagementSystem.Models;
using Abp.Application.Services;

using GroupManagementSystem.Utis;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Castle.Components.DictionaryAdapter.Xml;

namespace GroupManagementSystem.Manager.Services
{
    public class GMSTransactionAppService : ApplicationService, IGMSTrasactionAppService
    {
        private readonly IRepository<GMSTransaction, long> _gmstransactionRepository;
        private readonly IRepository<Transaction, long> _transactionRepo;
        private readonly IRepository<GroupParticipant, long> _groupParticipants;
        private readonly IRepository<GroupDetails, long> _groupDeailsRepo;


        private readonly IMapper _mapper;

        public GMSTransactionAppService(
            IRepository<GMSTransaction, long> transactionRepository,
             IRepository<Transaction, long> transactionRepo,
             IRepository<GroupParticipant, long> groupParticipants,
             IRepository<GroupDetails, long> groupDeailsRepo,
            IMapper mapper)
        {
            _gmstransactionRepository = transactionRepository;
            _transactionRepo = transactionRepo;
            _groupParticipants = groupParticipants;
            _groupDeailsRepo = groupDeailsRepo;
            _mapper = mapper;
        }

        public async Task<APIResponse<GMSTransactionResponseDTO>> AddGMSTransaction(TransactionResponseDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return new APIResponse<GMSTransactionResponseDTO>
                    {
                        result = null,
                        message = "The request is invalid"
                    };
                }

                // Map DTO to entity
                var entity = new GMSTransaction
                {


                    GroupMemberRefNO = dto.GroupMemberRefNO,
                    PaymentStructureId = dto.PaymentStructureId,
                    TransId = dto.Id
                };
                // Set tenant ID if needed (based on your ABP setup)
                entity.TransactionDate = DateTime.UtcNow;
                entity.TenantId = AbpSession.TenantId ?? 1;

                // Insert into DB
                var insertedEntity = await _gmstransactionRepository.InsertAsync(entity);
                await CurrentUnitOfWork.SaveChangesAsync();

                // Map back to response DTO

                return new APIResponse<GMSTransactionResponseDTO>
                {
                    result = null,
                    message = "GMSTransaction added successfully"
                };
            }
            catch (Exception ex)
            {
                // Optionally log the exception

                return new APIResponse<GMSTransactionResponseDTO>
                {
                    result = null,
                    message = $"Failed to add transaction: {ex.Message}"
                };
            }
        }


        public async Task<APIResponse<List<GMSTransactionResponseDTO>>> GetGMSTransaction(GMSTransactionFilterDTO dto)
        {
            try
            {
                var isGroupExist = await _groupDeailsRepo.FirstOrDefaultAsync(g => g.Id == dto.GroupId);

                if (isGroupExist == null)
                {
                     return new APIResponse<List<GMSTransactionResponseDTO>>
                {
                    result = null,
                    message = "No group with this GroupId "
                };
                }
                var groupParticipantQueryable = _groupParticipants.GetAll()
                .Where(gp => gp.GroupId == dto.GroupId );
                   
                var gmsTransactionQueryable = _gmstransactionRepository.GetAllIncluding(gms => gms.PaymentStructure)
                    .Where(gms => gms.TenantId == AbpSession.TenantId);

                var transactionQueryable = _transactionRepo.GetAllIncluding(t => t.PaymentStructure)
                    .Where(t => t.TenantId == AbpSession.TenantId);

                var query = groupParticipantQueryable
                    .Join(gmsTransactionQueryable,
                        gp => gp.GroupMemberRefNO,
                        gms => gms.GroupMemberRefNO,
                        (gp, gms) => new { gp, gms }
                    )
                    .Join(transactionQueryable,
                        temp => temp.gms.TransId,
                        trans => trans.Id,
                        (temp, trans) => new
                        {
                            GroupParticipant = temp.gp,
                            GMSTransaction = temp.gms,
                            Transaction = trans
                        }
                    )
                    .AsQueryable();

                if (!string.IsNullOrEmpty(dto.GroupMemberRefNO))
                {
                    query = query.Where(x => x.GMSTransaction.GroupMemberRefNO == dto.GroupMemberRefNO);
                }

                if (dto.TransactionDate.HasValue)
                {
                    query = query.Where(x => x.Transaction.TransactionDate.Date == dto.TransactionDate.Value.Date);
                }

                if (dto.PaymentStructureId.HasValue)
                {
                    query = query.Where(x => x.GMSTransaction.PaymentStructureId == dto.PaymentStructureId);
                }

            
                // Select into your custom DTO
                var resultList = await query.Select(x => new GMSTransactionResponseDTO
                {
                    GroupMemberRefNO = x.GMSTransaction.GroupMemberRefNO,
                    TransId = x.GMSTransaction.TransId,
                    TransactionDate = x.Transaction.TransactionDate,
                    Amount = x.Transaction.Amount,
                    Mode = x.Transaction.Mode,
                    PaymentStructureName = x.Transaction.PaymentStructure.Name,
                    PaymentStructureId = x.Transaction.PaymentStructureId

                }).ToListAsync();


                return new APIResponse<List<GMSTransactionResponseDTO>>
                {
                    result = resultList,
                    message = "fetched succesfully "
                };

            }
            catch (System.Exception ex)
            {

                return new APIResponse<List<GMSTransactionResponseDTO>>
                {
                    result = null,
                    message = "fetched Failed " + ex.Message
                };
            }

        }


    }
}