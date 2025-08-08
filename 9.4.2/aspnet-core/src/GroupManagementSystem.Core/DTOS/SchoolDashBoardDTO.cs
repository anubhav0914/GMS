using System;
using System.Collections.Generic;

namespace GroupManagementSystem.DTOS;

public class SchoolDashBoardDTO
{
    public long TotalStudent { get; set; }
    public long ToatalTeacher { get; set; }
    public long LastMonthCollections { get; set; }
    public List<GMSTransactionResponseDTO> RecenTransaction { get; set; }

}
