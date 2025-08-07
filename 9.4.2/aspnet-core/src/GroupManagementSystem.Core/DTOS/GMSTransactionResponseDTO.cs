using System;

namespace GroupManagementSystem.DTOS;

public class GMSTransactionResponseDTO
{   
    public long Id { get; set; }
    public string GroupMemberRefNO { get; set; }
    public DateTime TransactionDate { get; set; }
    public long TransId { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public string Mode { get; set; }
    public string TransactionReferenceId { get; set; }
    public string PaymentStructureName { get; set; }
    public long PaymentStructureId { get; set; }
}
