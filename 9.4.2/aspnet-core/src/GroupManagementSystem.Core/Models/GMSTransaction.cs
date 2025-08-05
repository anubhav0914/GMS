using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace GroupManagementSystem.Models;

public class GMSTransaction : Entity<long>
{   
    public string RefNo { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public long TransId { get; set; }
    public long PaymentStructureId { get; set; }
    public TransactionType TransactionType { get; set; }
    public TransactionStatus Status { get; set; }
    public TransactionMode Mode { get; set; }

    

    [ForeignKey(nameof(TransId))]
    public virtual Transaction Transaction { get; set; }

    [ForeignKey(nameof(PaymentStructureId))]
    public virtual PaymentStructure PaymentStructure { get; set; }

    public virtual GroupParticipant GroupParticipant { get; set; }
}

