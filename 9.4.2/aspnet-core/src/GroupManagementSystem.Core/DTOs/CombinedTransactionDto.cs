using System;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.DTOs;

public class CombinedTransactionDto
{
    public long GmsTransactionId { get; set; }
    public string RefNo { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }

    // From PaymentStructure
    public string FeeStructure { get; set; }

    // From GroupParticipant
    public string ParticipantRefNo { get; set; }
    public MemberType MemberType { get; set; }

    public string UserName { get; set; }

    public TransactionType TransactionType { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
