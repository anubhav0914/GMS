using System;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using AutoMapper;
using GroupManagementSystem.DTOS;
using GroupManagementSystem.Manager.Interfaces;
using GroupManagementSystem.Models;
using GroupManagementSystem.Utis;

namespace GroupManagementSystem.Manager.Services
{
    public class GMSTransactionAppService : IGMSTrasactionAppService
    {
        private readonly IRepository<GMSTransaction, long> _transactionRepository;
        private readonly IMapper _mapper;

        public GMSTransactionAppService(
            IRepository<GMSTransaction, long> transactionRepository,
            IMapper mapper)
        {
            _transactionRepository = transactionRepository;
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
                        message = "The request is Invalid"
                    };
                }
                return new APIResponse<GMSTransactionResponseDTO>
                {
                    result = null,
                    message = "The request is Invalid"
                };

            }
            catch (Exception ex)
            {
                return new APIResponse<GMSTransactionResponseDTO>
                {
                    result = null,
                    message = "The request is Invalid"
                };
            }
        }

        public Task<APIResponse<GMSTransactionResponseDTO>> GetGMSTransaction(TransactionResponseDTO dto)
        {
            throw new NotImplementedException();
        }
    }
    
    
}
