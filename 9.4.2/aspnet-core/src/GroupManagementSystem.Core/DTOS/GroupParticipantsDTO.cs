using System;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.DTOS;

public class GroupParticipantsDTO
{
    public MemberType? MemberType { get; set; }
    public string? GroupMemberRefNO { get; set; }
    public long GroupId { get; set; }
}
