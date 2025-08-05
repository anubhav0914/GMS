using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace GroupManagementSystem.Models;

public class GroupParticipant : Entity<long>
{
    public string RefNo { get; set; }
    public MemberType MemberType { get; set; }
    public long GroupTypeId { get; set; }
    public string UserName { get; set; }
    public string Emial { get; set; }
    public string PhoneNumber { get; set; }
    public long TenantId { get; set; }

    [ForeignKey(nameof(GroupTypeId))]
    public virtual GroupType GroupType { get; set; }
}

public enum MemberType
{
    Student, Teacher, Admin,Farmer,Father
}