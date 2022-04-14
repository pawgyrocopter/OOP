using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab1.Migrations
{
    public partial class codefirst1123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FactoryType = table.Column<string>(type: "TEXT", nullable: true),
                    UNP = table.Column<string>(type: "TEXT", nullable: true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    UrlAdress = table.Column<string>(type: "TEXT", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    SecondName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    SeriesAndPassportNumber = table.Column<string>(type: "TEXT", nullable: true),
                    IdentificationNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    FactoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsAproved = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Money = table.Column<double>(type: "REAL", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    FactoryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Money = table.Column<double>(type: "REAL", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    BankId = table.Column<int>(type: "INTEGER", nullable: false),
                    Percent = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<string>(type: "TEXT", nullable: false),
                    EndTime = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credits_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deposit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Money = table.Column<double>(type: "REAL", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposit_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Money = table.Column<double>(type: "REAL", nullable: false),
                    BankId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<string>(type: "TEXT", nullable: false),
                    EndTime = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plans_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "BankId", "Discriminator", "FactoryType", "Name", "UNP", "UrlAdress" },
                values: new object[] { 1, 1, "Bank", null, "PriorBank", null, null });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "BankId", "Discriminator", "FactoryType", "Name", "UNP", "UrlAdress" },
                values: new object[] { 2, 2, "Bank", null, "MTBank", null, null });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "BankId", "Discriminator", "FactoryType", "Name", "UNP", "UrlAdress" },
                values: new object[] { 3, 3, "Bank", null, "BelWeb", null, null });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "BankId", "Discriminator", "FactoryType", "Name", "UNP", "UrlAdress" },
                values: new object[] { 4, 1, "Factory", "Rabotygi", "Super Compony", "supercode", "rabotygi.com" });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "BankId", "Discriminator", "FactoryType", "Name", "UNP", "UrlAdress" },
                values: new object[] { 5, 2, "Factory", "NotRabotygi", "Mega Compony", "megacode", "notrabotygi.com" });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "BankId", "Discriminator", "FactoryType", "Name", "UNP", "UrlAdress" },
                values: new object[] { 6, 3, "Factory", "students", "BSUIR Compony", "student.com", "students.com" });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "BankId", "Discriminator", "FactoryType", "Name", "UNP", "UrlAdress" },
                values: new object[] { 7, 1, "Factory", "nones", "Noone Compony", "nonecode", "nones.com" });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "BankId", "Discriminator", "FactoryType", "Name", "UNP", "UrlAdress" },
                values: new object[] { 8, 2, "Factory", "fucks", "Fuck Compony", "fuckcode", "fucks.com" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "user" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "client" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "specialist" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "manager" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "operator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "FirstName", "IdentificationNumber", "LastName", "Password", "PhoneNumber", "RoleId", "SecondName", "SeriesAndPassportNumber" },
                values: new object[] { 123, "User", null, null, null, null, null, null, 1, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_ClientId",
                table: "Bill",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_ClientId",
                table: "Credits",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposit_ClientId",
                table: "Deposit",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_ClientId",
                table: "Plans",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "Deposit");

            migrationBuilder.DropTable(
                name: "Factories");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
