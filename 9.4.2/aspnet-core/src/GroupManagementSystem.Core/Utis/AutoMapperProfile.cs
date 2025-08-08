using System;
using AutoMapper;
using GroupManagementSystem.DTOS;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.Utis;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TransactionRequestDTO, Transaction>();
        CreateMap<Transaction, TransactionResponseDTO>();
        CreateMap<GroupDetailsRequestDTO, GroupDetails>();
        CreateMap<GroupDetails, GroupDetailsResponseDTO>();
        CreateMap<PaymentStructureRequestDTO, PaymentStructure>();
        CreateMap<PaymentStructure, PaymentStructureResponseDTO>();
    }
}