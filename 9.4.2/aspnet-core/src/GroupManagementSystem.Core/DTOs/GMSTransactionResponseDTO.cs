using System;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.DTOs;

public class GMSTransactionResponseDTO
{
    public long Id { get; set; }
    public string RefNo { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public long TransId { get; set; }
    public TransactionStatus Status { get; set; }
    public TransactionMode Mode { get; set; }
    public TransactionType Type { get; set; }

    public long PaymentStructureId { get; set; }

}
