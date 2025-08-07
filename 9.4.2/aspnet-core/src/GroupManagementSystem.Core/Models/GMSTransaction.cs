using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace GroupManagementSystem.Models;

public class GMSTransaction : FullAuditedEntity<long>, IMustHaveTenant
{
    public string GroupMemberRefNO { get; set; }
    public long TransId { get; set; }
    public DateTime TransactionDate { get; set; }
    public long PaymentStructureId { get; set; }
    public int TenantId { get; set; }
    public PaymentStructure PaymentStructure { get; set; }
    public Transaction Transaction { get; set; }
}
