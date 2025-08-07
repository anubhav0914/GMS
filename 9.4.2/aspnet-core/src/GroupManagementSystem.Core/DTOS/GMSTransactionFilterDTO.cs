using System;

namespace GroupManagementSystem.DTOS;

public class GMSTransactionFilterDTO
{
    public string? GroupMemberRefNO { get; set; }
    public DateTime? TransactionDate { get; set; }
    public long? TransId { get; set; }
    public long? PaymentStructureId { get; set; }
}
