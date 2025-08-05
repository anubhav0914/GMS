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
        public DbSet<GroupType> GroupTypes { get; set; }
        public DbSet<GroupParticipant> GroupParticipants { get; set; }

        public GroupManagementSystemDbContext(DbContextOptions<GroupManagementSystemDbContext> options)
            : base(options)
        {
        }
        
         protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Transaction>(b => {
                b.ToTable("Transactions");
                b.HasKey(x => x.Id);
                b.Property(x => x.Amount).HasColumnType("decimal(18,2)");
                b.HasMany(x => x.GMSTransactions)
                 .WithOne(x => x.Transaction)
                 .HasForeignKey(x => x.TransId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<GMSTransaction>(b =>
            {
                b.ToTable("GMSTransactions");
                b.HasKey(x => x.Id);
                b.Property(x => x.Amount).HasColumnType("decimal(18,2)");
                b.HasOne(x => x.PaymentStructure)
                 .WithMany(x => x.GMSTransactions)
                 .HasForeignKey(x => x.PaymentStructureId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<PaymentStructure>(b =>
            {
                b.ToTable("PaymentStructure");
                b.HasKey(x => x.Id);
                b.Property(x => x.Amount).HasColumnType("decimal(18,2)");
                b.HasOne(x => x.GroupType)
                 .WithMany(x => x.PaymentStructures)
                 .HasForeignKey(x => x.GroupTypeId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<GroupType>(b => {
                b.ToTable("GroupTypes");
                b.HasKey(x => x.Id);
            });

            builder.Entity<GroupParticipant>(b =>{
                b.ToTable("GroupParticipants");
                b.HasKey(x => x.Id);
                b.HasOne(x => x.GroupType)
                 .WithMany(x => x.GroupParticipants)
                 .HasForeignKey(x => x.GroupTypeId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
        }
       
    }
    }