using System;
using System.Threading.Tasks;
using Abp.AutoMapper;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.DTOS;

[AutoMapFrom(typeof(GroupDetails))]
[AutoMapTo(typeof(GroupDetails))]
public class GroupDetailsResponseDTO
{
    public long Id { get; set; }
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
    public long GroupTypeId { get; set; }
    public string Frequency { get; set; }
}
