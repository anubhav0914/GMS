using System;
using System.Collections.Generic;

namespace GroupManagementSystem.DTOs;

public class DashboardDto
{
    public int TotalStudents { get; set; }
    public int TotalTeachers { get; set; }
    public decimal MonthlyRevenue { get; set; }

    public List<TransactionSummaryDto> RecentTransactions { get; set; }
}

