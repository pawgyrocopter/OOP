using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab1.Migrations
{
    public partial class eweqw13eqwqwe123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillCreations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    BankName = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillCreations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Procent = table.Column<string>(type: "TEXT", nullable: false),
                    BankId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Procent = table.Column<string>(type: "TEXT", nullable: false),
                    BankId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanInfos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Procent" },
                values: new object[] { 1, 1, "3" });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Procent" },
                values: new object[] { 2, 1, "6" });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Procent" },
                values: new object[] { 3, 1, "12" });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Procent" },
                values: new object[] { 4, 1, "24" });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Procent" },
                values: new object[] { 5, 1, ">24" });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Procent" },
                values: new object[] { 6, 2, "3" });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Procent" },
                values: new object[] { 7, 2, "6" });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Procent" },
                values: new object[] { 8, 2, "12" });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Procent" },
                values: new object[] { 9, 2, "24" });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Procent" },
                values: new object[] { 10, 2, ">24" });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Procent" },
                values: new object[] { 11, 3, "3" });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Procent" },
                values: new object[] { 12, 3, "6" });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Procent" },
                values: new object[] { 13, 3, "12" });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Procent" },
                values: new object[] { 14, 3, "24" });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Procent" },
                values: new object[] { 15, 3, ">24" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillCreations");

            migrationBuilder.DropTable(
                name: "CreditInfos");

            migrationBuilder.DropTable(
                name: "PlanInfos");
        }
    }
}
