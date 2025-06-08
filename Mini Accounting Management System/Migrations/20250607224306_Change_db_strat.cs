using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Accounting_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class Change_db_strat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoucherDCS_SubAccounts_SubAccountID",
                table: "VoucherDCS");

            migrationBuilder.CreateTable(
                name: "Journal_Vouchers",
                columns: table => new
                {
                    J_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubAccountID = table.Column<int>(type: "int", nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal_Vouchers", x => x.J_ID);
                    table.ForeignKey(
                        name: "FK_Journal_Vouchers_SubAccounts_SubAccountID",
                        column: x => x.SubAccountID,
                        principalTable: "SubAccounts",
                        principalColumn: "S_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment_Vouchers",
                columns: table => new
                {
                    Pay_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubAccountID = table.Column<int>(type: "int", nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_Vouchers", x => x.Pay_ID);
                    table.ForeignKey(
                        name: "FK_Payment_Vouchers_SubAccounts_SubAccountID",
                        column: x => x.SubAccountID,
                        principalTable: "SubAccounts",
                        principalColumn: "S_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reciept_Vouchers",
                columns: table => new
                {
                    R_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubAccountID = table.Column<int>(type: "int", nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reciept_Vouchers", x => x.R_ID);
                    table.ForeignKey(
                        name: "FK_Reciept_Vouchers_SubAccounts_SubAccountID",
                        column: x => x.SubAccountID,
                        principalTable: "SubAccounts",
                        principalColumn: "S_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Journal_Vouchers_SubAccountID",
                table: "Journal_Vouchers",
                column: "SubAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Vouchers_SubAccountID",
                table: "Payment_Vouchers",
                column: "SubAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Reciept_Vouchers_SubAccountID",
                table: "Reciept_Vouchers",
                column: "SubAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherDCS_SubAccounts_SubAccountID",
                table: "VoucherDCS",
                column: "SubAccountID",
                principalTable: "SubAccounts",
                principalColumn: "S_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoucherDCS_SubAccounts_SubAccountID",
                table: "VoucherDCS");

            migrationBuilder.DropTable(
                name: "Journal_Vouchers");

            migrationBuilder.DropTable(
                name: "Payment_Vouchers");

            migrationBuilder.DropTable(
                name: "Reciept_Vouchers");

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherDCS_SubAccounts_SubAccountID",
                table: "VoucherDCS",
                column: "SubAccountID",
                principalTable: "SubAccounts",
                principalColumn: "S_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
