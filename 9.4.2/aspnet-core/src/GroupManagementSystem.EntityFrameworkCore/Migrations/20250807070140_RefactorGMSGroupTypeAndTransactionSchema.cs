using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class RefactorGMSGroupTypeAndTransactionSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupDetails_GroupTypes_GroupTypeId",
                table: "GroupDetails");

            migrationBuilder.DropTable(
                name: "GroupTypes");

            migrationBuilder.DropIndex(
                name: "IX_GroupDetails_GroupTypeId",
                table: "GroupDetails");

            migrationBuilder.DropColumn(
                name: "TransId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PaymentStructures");

            migrationBuilder.DropColumn(
                name: "GroupTypeId",
                table: "GroupDetails");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "GMSTransactions");

            migrationBuilder.DropColumn(
                name: "Mode",
                table: "GMSTransactions");

            migrationBuilder.DropColumn(
                name: "ReceiptNumber",
                table: "GMSTransactions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "GMSTransactions");

            migrationBuilder.DropColumn(
                name: "TargetAccountId",
                table: "GMSTransactions");

            migrationBuilder.DropColumn(
                name: "TransactionReferenceId",
                table: "GMSTransactions");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "GMSTransactions");

            migrationBuilder.AddColumn<int>(
                name: "GMSGroupType",
                table: "GroupDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "TransId",
                table: "GMSTransactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TransactionId",
                table: "GMSTransactions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GMSTransactions_TransactionId",
                table: "GMSTransactions",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_GMSTransactions_Transactions_TransactionId",
                table: "GMSTransactions",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GMSTransactions_Transactions_TransactionId",
                table: "GMSTransactions");

            migrationBuilder.DropIndex(
                name: "IX_GMSTransactions_TransactionId",
                table: "GMSTransactions");

            migrationBuilder.DropColumn(
                name: "GMSGroupType",
                table: "GroupDetails");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "GMSTransactions");

            migrationBuilder.AddColumn<string>(
                name: "TransId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "PaymentStructures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GroupTypeId",
                table: "GroupDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "TransId",
                table: "GMSTransactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "GMSTransactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Mode",
                table: "GMSTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiptNumber",
                table: "GMSTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "GMSTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetAccountId",
                table: "GMSTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionReferenceId",
                table: "GMSTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "GMSTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroupTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupDetails_GroupTypeId",
                table: "GroupDetails",
                column: "GroupTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupDetails_GroupTypes_GroupTypeId",
                table: "GroupDetails",
                column: "GroupTypeId",
                principalTable: "GroupTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
