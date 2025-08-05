using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using GroupManagementSystem.DTOs;
using GroupManagementSystem.Managers.Interfaces;
using GroupManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupManagementSystem.Managers.Services;

public class DashboardAppService : ApplicationService, IDashboardAppService
{
    private readonly IRepository<GroupParticipant, long> _participantRepo;
    private readonly IRepository<GMSTransaction, long> _gmsTransactionRepo;
    private readonly IRepository<PaymentStructure, long> _paymentStructureRepo;

    public DashboardAppService(
        IRepository<GroupParticipant, long> participantRepo,
        IRepository<GMSTransaction, long> gmsTransactionRepo,
        IRepository<PaymentStructure, long> paymentStructureRepo)
    {
        _participantRepo = participantRepo;
        _gmsTransactionRepo = gmsTransactionRepo;
        _paymentStructureRepo = paymentStructureRepo;
    }

    public async Task<DashboardDto> GetAdminDashboardAsync()
    {
        var allParticipants = await _participantRepo
            .GetAll()
            .ToListAsync();

        var students = allParticipants.Count(p => p.MemberType == MemberType.Student);
        var teachers = allParticipants.Count(p => p.MemberType == MemberType.Teacher);

        var oneMonthAgo = DateTime.Now.AddMonths(-1);

        var transactions = await _gmsTransactionRepo
        .GetAllIncluding(t => t.PaymentStructure, t => t.Transaction)
        .Where(t => t.Date >= oneMonthAgo && t.TransactionType == TransactionType.Deposit)
        .ToListAsync();

        var monthlyRevenue = transactions
            .Where(t => t.Date >= oneMonthAgo && t.TransactionType == TransactionType.Deposit)
            .Sum(t => t.Amount);

        var recentTransactions = transactions
            .OrderByDescending(t => t.Date)
            .Take(5)
            .Select(t => new TransactionSummaryDto
            {
                Name = t.Transaction?.RefNo ?? "Unknown",
                RefNo = t.RefNo,
                FeeType = t.PaymentStructure?.Name ?? "",
                Amount = t.Amount,
                Date = t.Date
            }).ToList();

        return new DashboardDto
        {
            TotalStudents = students,
            TotalTeachers = teachers,
            MonthlyRevenue = monthlyRevenue,
            RecentTransactions = recentTransactions
        };
    }
}

