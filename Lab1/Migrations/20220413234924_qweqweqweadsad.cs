using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab1.Migrations
{
    public partial class qweqweqweadsad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Procent",
                table: "CreditInfos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "CreditInfos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Duration", "Procent" },
                values: new object[] { "3", 10 });

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Duration", "Procent" },
                values: new object[] { "6", 200 });

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Duration", "Procent" },
                values: new object[] { "12", 50 });

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Duration", "Procent" },
                values: new object[] { "24", 11 });

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Duration", "Procent" },
                values: new object[] { ">24", 12 });

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Duration", "Procent" },
                values: new object[] { "3", 13 });

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Duration", "Procent" },
                values: new object[] { "6", 100 });

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Duration", "Procent" },
                values: new object[] { "12", 1 });

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Duration", "Procent" },
                values: new object[] { "24", 2000 });

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Duration", "Procent" },
                values: new object[] { ">24", 2 });

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Duration", "Procent" },
                values: new object[] { "3", 3 });

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Duration", "Procent" },
                values: new object[] { "6", 2 });

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Duration", "Procent" },
                values: new object[] { "12", 10 });

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Duration", "Procent" },
                values: new object[] { "24", 10 });

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Duration", "Procent" },
                values: new object[] { ">24", 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "CreditInfos");

            migrationBuilder.AlterColumn<string>(
                name: "Procent",
                table: "CreditInfos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Procent",
                value: "3");

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Procent",
                value: "6");

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Procent",
                value: "12");

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Procent",
                value: "24");

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 5,
                column: "Procent",
                value: ">24");

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 6,
                column: "Procent",
                value: "3");

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 7,
                column: "Procent",
                value: "6");

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 8,
                column: "Procent",
                value: "12");

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 9,
                column: "Procent",
                value: "24");

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 10,
                column: "Procent",
                value: ">24");

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 11,
                column: "Procent",
                value: "3");

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 12,
                column: "Procent",
                value: "6");

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 13,
                column: "Procent",
                value: "12");

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 14,
                column: "Procent",
                value: "24");

            migrationBuilder.UpdateData(
                table: "CreditInfos",
                keyColumn: "Id",
                keyValue: 15,
                column: "Procent",
                value: ">24");
        }
    }
}
