using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab1.Migrations
{
    public partial class qwqweqweeee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Users_ClientId",
                table: "Bills");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Bills",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Users_ClientId",
                table: "Bills",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Users_ClientId",
                table: "Bills");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Bills",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Users_ClientId",
                table: "Bills",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
