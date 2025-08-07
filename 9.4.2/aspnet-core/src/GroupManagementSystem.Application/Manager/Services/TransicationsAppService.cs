using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using GroupManagementSystem.DTOS;
using GroupManagementSystem.Manager.Interfaces;
using GroupManagementSystem.Models;
using GroupManagementSystem.Utis;

namespace GroupManagementSystem.Manager.Services
{
    public class TransicationsAppService : ApplicationService, ITransicationsAppService
    {
        private readonly IRepository<Transaction, long> _transactionRepository;
        private readonly IRepository<GroupParticipant, long> _groupParticipantsRepository;

        private readonly IMapper _mapper;

        public TransicationsAppService(
            IRepository<Transaction, long> transactionRepository,
            IRepository<GroupParticipant, long> groupParticipantsRepository,
            IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _groupParticipantsRepository = groupParticipantsRepository;
            _mapper = mapper;
        }

        public async Task<APIResponse<TransactionResponseDTO>> CreateTransaction(TransactionRequestDTO dto)
        {
            try
            {   
                var isGroupRefNoExist = await _groupParticipantsRepository.FirstOrDefaultAsync(rf => rf.GroupMemberRefNO == dto.GroupMemberRefNO);

                if (isGroupRefNoExist == null)
                {
                    return new APIResponse<TransactionResponseDTO>
                    {
                        message = " The GroupRefNo is null",
                    };
                }

                var entity = _mapper.Map<Transaction>(dto);
                entity.TenantId = AbpSession.TenantId ?? throw new Exception("TenantId is null");

                var result = await _transactionRepository.InsertAsync(entity);
                
                // save it first to get the trasactionIdt 
                CurrentUnitOfWork.SaveChanges();

                var responseDto = _mapper.Map<TransactionResponseDTO>(result);
                responseDto.Id = result.Id.ToString();

                // CALL FOR ENTRY OF THE GMSTransaction here 
                

                return new APIResponse<TransactionResponseDTO>
                {
                    message = "Transaction Completed Sucessfuly",
                    result = responseDto
                };
            }
            catch (Exception ex)
            {
                return new APIResponse<TransactionResponseDTO>
                {
                    message = "Create Transaction Failed" + ex.Message,
                    result = null
                };
            }
        }
    }
}
