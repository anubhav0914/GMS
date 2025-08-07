using System;
using Abp.AutoMapper;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.DTOS;

[AutoMapFrom(typeof(Transaction))]
[AutoMapTo(typeof(Transaction))]



public class TransactionResponseDTO
{
    public long Id { get; set; }
    public string GroupMemberRefNO { get; set; }
    public string TargetAccountId { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public string TransId { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public string Mode { get; set; }
    public string ReceiptNumber { get; set; }
    public string TransactionReferenceId { get; set; }
    public long PaymentStructureId { get; set; }
}
