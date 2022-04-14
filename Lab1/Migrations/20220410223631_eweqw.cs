using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab1.Migrations
{
    public partial class eweqw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Bills_BankId",
                table: "Bills",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Factories_BankId",
                table: "Bills",
                column: "BankId",
                principalTable: "Factories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Factories_BankId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_BankId",
                table: "Bills");
        }
    }
}
