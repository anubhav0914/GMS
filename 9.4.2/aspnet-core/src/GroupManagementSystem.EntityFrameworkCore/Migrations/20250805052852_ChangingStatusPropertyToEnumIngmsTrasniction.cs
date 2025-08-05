using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class ChangingStatusPropertyToEnumIngmsTrasniction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "GMSTransactions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "GMSTransactions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
