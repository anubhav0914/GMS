using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class clearningDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "GroupParticipants");

            migrationBuilder.DropTable(
                name: "PaymentsTypes");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "PaymentStructures");

            migrationBuilder.DropTable(
                name: "GroupTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    Mode = table.Column<int>(type: "int", nullable: false),
                    RefNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    TransId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
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
                    GroupTypeId = table.Column<long>(type: "bigint", nullable: false),
                    MemberType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupParticipants_GroupTypes_GroupTypeId",
                        column: x => x.GroupTypeId,
                        principalTable: "GroupTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStructures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStructures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentStructures_GroupTypes_GroupTypeId",
                        column: x => x.GroupTypeId,
                        principalTable: "GroupTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentStructureId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionId = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collections_PaymentStructures_PaymentStructureId",
                        column: x => x.PaymentStructureId,
                        principalTable: "PaymentStructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collections_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentsTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentStructureId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentsTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentsTypes_PaymentStructures_PaymentStructureId",
                        column: x => x.PaymentStructureId,
                        principalTable: "PaymentStructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collections_PaymentStructureId",
                table: "Collections",
                column: "PaymentStructureId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_TransactionId",
                table: "Collections",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupParticipants_GroupTypeId",
                table: "GroupParticipants",
                column: "GroupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStructures_GroupTypeId",
                table: "PaymentStructures",
                column: "GroupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentsTypes_PaymentStructureId",
                table: "PaymentsTypes",
                column: "PaymentStructureId");
        }
    }
}
