using System;
using System.ComponentModel.DataAnnotations.Schema;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.DTOs;

public class GMSTransactionRequestDTO
{
  public string RefNo { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public long TransId { get; set; }
    public TransactionStatus Status { get; set; }
    public long PaymentStructureId { get; set; }


    
}
