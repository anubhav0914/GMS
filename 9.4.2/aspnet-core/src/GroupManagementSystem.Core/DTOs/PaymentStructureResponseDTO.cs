using System;

namespace GroupManagementSystem.DTOs;

public class PaymentStructureResponseDTO
{
    public long Id { get; set; }
    public long GroupTypeId { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public long GroupId { get; set; }
}
