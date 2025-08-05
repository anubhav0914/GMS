using System;
using System.Transactions;
using AutoMapper;
using GroupManagementSystem.DTOs;

namespace GroupManagementSystem.Utis;

public class TransactionMapperProfile : Profile
{
    public TransactionMapperProfile()
    {
        CreateMap<TransactionRequestDTO, Transaction>();
        CreateMap<TransactionResponseDTO, Transaction>().ReverseMap();
    }
}
