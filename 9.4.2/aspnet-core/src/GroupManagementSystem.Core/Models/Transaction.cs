using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace GroupManagementSystem.Models;

public class Transaction : FullAuditedEntity<long> ,IMustHaveTenant
{
    public string GroupMemberRefNO { get; set; }
    public string TargetAccountId { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }

    public string Mode { get; set; }
    public string ReceiptNumber { get; set; }
    public string TransactionReferenceId { get; set; }
    public int TenantId { get; set; }

    /// <summary>
    /// the Payment structure is here only for GMS Trasiction 
    /// there is no need of the PaymentStructureId in the Transaction table 
    /// it just taken as an input from the tailler
    /// </summary>
    /// 
    public long PaymentStructureId { get; set; }

    public PaymentStructure PaymentStructure { get; set; }

}
