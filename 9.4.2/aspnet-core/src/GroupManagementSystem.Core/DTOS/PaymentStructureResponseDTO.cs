using System;
using Abp.AutoMapper;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.DTOS;

[AutoMapFrom(typeof(PaymentStructure))]
[AutoMapTo(typeof(PaymentStructure))]
public class PaymentStructureResponseDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long GroupId { get; set; }
}
