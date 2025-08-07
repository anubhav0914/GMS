using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace GroupManagementSystem.Models;

public class GroupParticipant : FullAuditedEntity<long>, IMustHaveTenant
{
    public string GroupMemberRefNO { get; set; }
    public MemberType MemberType { get; set; }
    public long GroupId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int TenantId { get; set; }
    public GroupDetails Group { get; set; }
}

public enum MemberType
{
    Student,
    Teacher,
    Farmer,
    Father,
}