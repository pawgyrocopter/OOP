using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab1.Migrations
{
    public partial class qq3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bills_BankId",
                table: "Bills");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BankId",
                table: "Bills",
                column: "BankId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bills_BankId",
                table: "Bills");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BankId",
                table: "Bills",
                column: "BankId");
        }
    }
}
