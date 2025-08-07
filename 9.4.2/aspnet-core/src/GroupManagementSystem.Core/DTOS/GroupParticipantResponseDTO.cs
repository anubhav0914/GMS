using System;
using Abp.AutoMapper;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.DTOS;

[AutoMapFrom(typeof(GroupParticipant))]
[AutoMapTo(typeof(GroupParticipant))]
public class GroupParticipantResponseDTO
{
    public long Id { get; set; }
    public MemberType MemberType { get; set; }
    public string GroupMemberRefNO { get; set; }
    public long GroupId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
