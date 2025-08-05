using System;
using System.Collections.Generic;
using Abp.Domain.Entities;

namespace GroupManagementSystem.Models;

public class GroupType : Entity<long>
{
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<PaymentStructure> PaymentStructures { get; set; }
    public virtual ICollection<GroupParticipant> GroupParticipants { get; set; }
}
