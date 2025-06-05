using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Accounting_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class Fix_the_database_issue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    A_ID = table.Column<int>(type: "int", nullable: false),
                    Acc_Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalBalance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.A_ID);
                });

            migrationBuilder.CreateTable(
                name: "SubAccounts",
                columns: table => new
                {
                    S_ID = table.Column<int>(type: "int", nullable: false),
                    Type_A_ID = table.Column<int>(type: "int", nullable: false),
                    Sub_Acc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubAccounts", x => x.S_ID);
                    table.ForeignKey(
                        name: "FK_SubAccounts_AccountTypes_Type_A_ID",
                        column: x => x.Type_A_ID,
                        principalTable: "AccountTypes",
                        principalColumn: "A_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypes_Acc_Type",
                table: "AccountTypes",
                column: "Acc_Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubAccounts_Type_A_ID_Sub_Acc",
                table: "SubAccounts",
                columns: new[] { "Type_A_ID", "Sub_Acc" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubAccounts");

            migrationBuilder.DropTable(
                name: "AccountTypes");
        }
    }
}
