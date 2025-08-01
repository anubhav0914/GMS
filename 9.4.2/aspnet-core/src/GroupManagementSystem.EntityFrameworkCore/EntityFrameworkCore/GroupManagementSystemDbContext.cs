using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using GroupManagementSystem.Authorization.Roles;
using GroupManagementSystem.Authorization.Users;
using GroupManagementSystem.MultiTenancy;

namespace GroupManagementSystem.EntityFrameworkCore
{
    public class GroupManagementSystemDbContext : AbpZeroDbContext<Tenant, Role, User, GroupManagementSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public GroupManagementSystemDbContext(DbContextOptions<GroupManagementSystemDbContext> options)
            : base(options)
        {
        }
    }
}
