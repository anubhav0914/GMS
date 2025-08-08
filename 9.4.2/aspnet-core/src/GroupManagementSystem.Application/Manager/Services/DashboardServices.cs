using Abp.Application.Services;
using Abp.Domain.Repositories;
using GroupManagementSystem.DTOS;
using GroupManagementSystem.Manager.Interfaces;
using GroupManagementSystem.Models;
using GroupManagementSystem.Utis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GroupManagementSystem.Manager.Services
{
    public class DashBoardServices : ApplicationService, IDashBoardServices
    {
        private readonly IRepository<GroupParticipant, long> _groupParticipantRepo;
        private readonly IRepository<Transaction, long> _transactionRepo;
        private readonly IRepository<GMSTransaction, long> _gmsTransactionRepo;

        public DashBoardServices(
            IRepository<GroupParticipant, long> groupParticipantRepo,
            IRepository<Transaction, long> transactionRepo,
            IRepository<GMSTransaction, long> gmsTransactionRepo)
        {
            _groupParticipantRepo = groupParticipantRepo;
            _transactionRepo = transactionRepo;
            _gmsTransactionRepo = gmsTransactionRepo;
        }

        public async Task<APIResponse<SchoolDashBoardDTO>> GetSchoolDashBoard(long groupId)
        {
            try
            {
                var result = new SchoolDashBoardDTO();

                // Total Students
                result.TotalStudent = await _groupParticipantRepo
                    .GetAll()
                    .Where(x => x.GroupId == groupId && x.MemberType == MemberType.Student)
                    .CountAsync();

                // Total Teachers
                result.ToatalTeacher = await _groupParticipantRepo
                    .GetAll()
                    .Where(x => x.GroupId == groupId && x.MemberType == MemberType.Teacher)
                    .CountAsync();

                // Last Month's Collection
                var oneMonthAgo = DateTime.UtcNow.AddMonths(-1);
                result.LastMonthCollections = await _transactionRepo
                    .GetAll()
                    .Where(x => x.TransactionDate >= oneMonthAgo && x.TransactionDate <= DateTime.UtcNow)
                    .SumAsync(x => (long)x.Amount); // Cast decimal to long

                // Recent Transactions

                var twoDaysAgo = DateTime.UtcNow.AddDays(-2);

                var recentTransactions = await _groupParticipantRepo
                    .GetAll()
                    .Where(gp => gp.GroupId == groupId)
                    .Join(
                        _gmsTransactionRepo.GetAll(),
                        gp => gp.GroupMemberRefNO,
                        gms => gms.GroupMemberRefNO,
                        (gp, gms) => new { gp, gms }
                    )
                    .Join(
                        _transactionRepo.GetAll(),
                        joined => joined.gms.TransId,
                        t => t.Id,
                        (joined, t) => new { GmsTransaction = joined.gms, Transaction = t }
                    )
                    .Where(x => x.Transaction.TransactionDate >= twoDaysAgo)
                    .OrderByDescending(x => x.Transaction.TransactionDate)
                    .Take(100)
                    .Select(x => new GMSTransactionResponseDTO
                    {
                        Id = x.GmsTransaction.Id,
                        GroupMemberRefNO = x.GmsTransaction.GroupMemberRefNO,
                        TransId = x.GmsTransaction.TransId,
                        // Include other GMSTransaction fields here if needed
                        TransactionDate = x.Transaction.TransactionDate,
                        Amount = x.Transaction.Amount,
                        Mode = x.Transaction.Mode,
                        Status = x.Transaction.Status,
                        // ReceiptNumber = x.Transaction.ReceiptNumber, // if needed
                    })
                    .ToListAsync();



                result.RecenTransaction = recentTransactions;

                return new APIResponse<SchoolDashBoardDTO>
                {
                    message = "DashBoard result fechted ",
                    result = result
                };
            }
            catch (System.Exception ex)
            {

                return new APIResponse<SchoolDashBoardDTO>
                {
                    message = "DashBoard result failed " + ex.Message,
                    result = null
                };
            }
        }
    }
}
