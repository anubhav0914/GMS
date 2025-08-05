using System;

namespace GroupManagementSystem.DTOs;

public class TransactionSummaryDto
{
    public string Name { get; set; } 
    public string RefNo { get; set; } 
    public string FeeType { get; set; } 
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}

