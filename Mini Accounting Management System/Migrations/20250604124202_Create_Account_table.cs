using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mini_Accounting_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class Create_Account_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    P_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acc_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sub_Acc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.P_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

           

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a3127e41-f49e-48ab-8c55-42c62c5107e1", null, "Viewer", "Viewer" },
                    { "e03b77b1-561e-4077-8367-893b5d044d61", null, "Admin", "Admin" },
                    { "f397b00b-18ef-4db5-8f6e-9bfefa913a20", null, "Accountant", "Accountant" }
                });
        }
    }
}
