using System;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.DTOs;

public class GroupParticipantResponseDTO
{
    public long Id { get; set; }
    public string RefNo { get; set; }
    public MemberType MemberType { get; set; }
    public string UserName { get; set; }
    public string Emial { get; set; }
    public string PhoneNumber { get; set; }
    public long GroupTypeId { get; set; }

}
