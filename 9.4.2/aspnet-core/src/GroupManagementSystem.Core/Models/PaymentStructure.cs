using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace GroupManagementSystem.Models;

public class PaymentStructure : FullAuditedEntity<long>, IMustHaveTenant
{
    public string Name { get; set; }
    public long GroupId { get; set; }
    public int TenantId { get; set; }
    public GroupDetails Group { get; set; }
    public ICollection<GMSTransaction> GMSTransactions { get; set; }
    public ICollection<Transaction> Transactions { get; set; }

}


