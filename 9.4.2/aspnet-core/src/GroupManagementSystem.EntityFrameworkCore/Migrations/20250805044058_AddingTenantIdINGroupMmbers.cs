using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddingTenantIdINGroupMmbers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "GroupParticipants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "GroupParticipants");
        }
    }
}
