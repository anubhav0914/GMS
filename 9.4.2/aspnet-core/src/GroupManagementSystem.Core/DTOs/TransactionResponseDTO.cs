using System;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.DTOs;

public class TransactionResponseDTO
{  
    public long Id { get; set; }
   public string RefNo { get; set; }
    public decimal Amount { get; set; }
    public TransactionStatus Status { get; set; }
    public TransactionType Type { get; set; }

    public TransactionMode Mode { get; set; }
    public long TenantId { get; set; }
    public long GroupId { get; set; }
    public DateTime Date { get; set; }
}
