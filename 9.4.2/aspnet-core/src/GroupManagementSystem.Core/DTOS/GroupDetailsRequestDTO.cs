using System;
using Abp.AutoMapper;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.DTOS;
 
 
[AutoMapFrom(typeof(GroupDetails))]
[AutoMapTo(typeof(GroupDetails))]

public class GroupDetailsRequestDTO
{
    public string GroupName { get; set; }
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
    public GMSGroupType GroupType { get; set; }
    public string Frequency { get; set; }
}
