using System;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.DTOs;

public class GroupParticipantRequestDTO
{   
    public MemberType MemberType { get; set; }
    public string UserName { get; set; }
    public string Emial { get; set; }
    public string PhoneNumber { get; set; }
    public long GroupTypeId { get; set; }

}


public class PagedParticipantInputDto
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public MemberType? MemberType { get; set; } // Enum filter
}
