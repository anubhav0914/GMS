using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace GroupManagementSystem.Models;
public class GroupDetails : FullAuditedEntity<long>, IMustHaveTenant
{
    public string GroupName { get; set; }
    public long UserId { get; set; }
    public string ChairmanName { get; set; }
    public string ChairmanMobileNumber { get; set; }
    public string GroupRegion { get; set; }
    public string GroupDistrict { get; set; }
    public string GroupWard { get; set; }
    public string OfficeNumber { get; set; }
    public string GroupNumber { get; set; }
    public long MemberId { get; set; }
    public int TypeId { get; set; }
    public int PolicyId { get; set; }
    public GMSGroupType GMSGroupType { get; set; }
    public string Frequency { get; set; }
    public int TenantId { get; set; }

    public ICollection<GroupParticipant> Participants { get; set; }
    public ICollection<PaymentStructure> PaymentStructures { get; set; }
}

public enum GMSGroupType
{
    School,
    Farmers,
    Church
}