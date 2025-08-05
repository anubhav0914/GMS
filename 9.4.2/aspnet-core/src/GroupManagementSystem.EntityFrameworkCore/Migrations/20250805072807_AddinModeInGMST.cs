using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddinModeInGMST : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mode",
                table: "GMSTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "GMSTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mode",
                table: "GMSTransactions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "GMSTransactions");
        }
    }
}
