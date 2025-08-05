using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Mode = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupParticipants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberType = table.Column<int>(type: "int", nullable: false),
                    GroupTypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupParticipants_GroupTypes_GroupTypeId",
                        column: x => x.GroupTypeId,
                        principalTable: "GroupTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStructure",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStructure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentStructure_GroupTypes_GroupTypeId",
                        column: x => x.GroupTypeId,
                        principalTable: "GroupTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GMSTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentStructureId = table.Column<long>(type: "bigint", nullable: false),
                    GroupParticipantId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMSTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GMSTransactions_GroupParticipants_GroupParticipantId",
                        column: x => x.GroupParticipantId,
                        principalTable: "GroupParticipants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GMSTransactions_PaymentStructure_PaymentStructureId",
                        column: x => x.PaymentStructureId,
                        principalTable: "PaymentStructure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GMSTransactions_Transactions_TransId",
                        column: x => x.TransId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GMSTransactions_GroupParticipantId",
                table: "GMSTransactions",
                column: "GroupParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_GMSTransactions_PaymentStructureId",
                table: "GMSTransactions",
                column: "PaymentStructureId");

            migrationBuilder.CreateIndex(
                name: "IX_GMSTransactions_TransId",
                table: "GMSTransactions",
                column: "TransId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupParticipants_GroupTypeId",
                table: "GroupParticipants",
                column: "GroupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStructure_GroupTypeId",
                table: "PaymentStructure",
                column: "GroupTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GMSTransactions");

            migrationBuilder.DropTable(
                name: "GroupParticipants");

            migrationBuilder.DropTable(
                name: "PaymentStructure");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "GroupTypes");
        }
    }
}
