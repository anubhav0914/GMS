using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace GroupManagementSystem.EntityFrameworkCore
{
    public static class GroupManagementSystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<GroupManagementSystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<GroupManagementSystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
