using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab1.Migrations
{
    public partial class eweqw13eqw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBank",
                table: "Factories",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Factories",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsBank",
                value: true);

            migrationBuilder.UpdateData(
                table: "Factories",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsBank",
                value: true);

            migrationBuilder.UpdateData(
                table: "Factories",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsBank",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBank",
                table: "Factories");
        }
    }
}
