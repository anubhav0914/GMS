using System;
using Abp.AutoMapper;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.DTOS;

[AutoMapFrom(typeof(PaymentStructure))]
[AutoMapTo(typeof(PaymentStructure))]

public class PaymentStructureRequestDTO
{
    public string Name { get; set; }
    public long GroupId { get; set; }
}

public class PaymentStructureUpdateDTO : PaymentStructureRequestDTO
{
    public int id { get; set; }
}
