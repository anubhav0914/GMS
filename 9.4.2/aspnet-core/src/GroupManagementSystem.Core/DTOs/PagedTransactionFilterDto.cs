using System;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.DTOs;

public class PagedTransactionFilterDto
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    // Optional filters
    public string RefNo { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public long? PaymentStructureId { get; set; }
    public MemberType? MemberType { get; set; }
    public TransactionType? TransactionType { get; set; }
}
