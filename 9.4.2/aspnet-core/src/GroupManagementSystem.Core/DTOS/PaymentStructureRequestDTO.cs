using System;

namespace GroupManagementSystem.DTOS;

public class PaymentStructureRequestDTO
{
   public string Name { get; set; }
    public string Amount { get; set; }
    public long GroupId { get; set; }
}
