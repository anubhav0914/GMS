using System;

namespace GroupManagementSystem.DTOS;

public class PaymentStructureResponseDTO
{   
    public long Id { get; set;}
    public string Name { get; set; }
    public string Amount { get; set; }
    public long GroupId { get; set; }
}
