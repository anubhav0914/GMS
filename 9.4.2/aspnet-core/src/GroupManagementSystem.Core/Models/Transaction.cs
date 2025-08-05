using System;
using System.Collections.Generic;
using Abp.Domain.Entities;

namespace GroupManagementSystem.Models;

public class Transaction : Entity<long>
{
    public string RefNo { get; set; }
    public decimal Amount { get; set; }
    public TransactionMode Mode { get; set; }

    public TransactionType TransactionType { get; set; }
    public TransactionStatus Status { get; set; }
        public DateTime Date { get; set; }


    public long TenantId { get; set; }
    public long GroupId { get; set; }

    public virtual ICollection<GMSTransaction> GMSTransactions { get; set; }
}

public enum TransactionMode
{
    Cash, Online, BankTransfer
}

public enum TransactionType
{
    Deposit,
    Disbursement,
    Revert
}

public enum TransactionStatus
{
    Initiated , Pending , Success
}