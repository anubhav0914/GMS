using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using GroupManagementSystem.Authorization.Roles;
using GroupManagementSystem.Authorization.Users;
using GroupManagementSystem.MultiTenancy;
using GroupManagementSystem.Models;

namespace GroupManagementSystem.EntityFrameworkCore
{
    public class GroupManagementSystemDbContext : AbpZeroDbContext<Tenant, Role, User, GroupManagementSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<GMSTransaction> GMSTransactions { get; set; }
        public DbSet<PaymentStructure> PaymentStructures { get; set; }
        public DbSet<GroupDetails> GroupDetails { get; set; }
        public DbSet<GroupParticipant> GroupParticipants { get; set; }

        public GroupManagementSystemDbContext(DbContextOptions<GroupManagementSystemDbContext> options)
            : base(options)
        {
            
        }
        
        
       
    }
    }