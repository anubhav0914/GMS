using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace GroupManagementSystem.Models;

public class PaymentStructure : Entity<long>
{
    public long GroupTypeId { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public long GroupId { get; set; }

    [ForeignKey(nameof(GroupTypeId))]
    public virtual GroupType GroupType { get; set; }

    public virtual ICollection<GMSTransaction> GMSTransactions { get; set; }
}

