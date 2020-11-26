using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestCookieWeb.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id_UserRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ChangeUserRole = table.Column<bool>(type: "bit", nullable: false),
                    ManageUserList = table.Column<bool>(type: "bit", nullable: false),
                    WorkWithHierarchy = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKUserRole", x => x.Id_UserRole);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotificationPermission = table.Column<bool>(type: "bit", nullable: false),
                    IdUserRole = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKUser", x => x.Id_User);
                    table.ForeignKey(
                        name: "R_21",
                        column: x => x.IdUserRole,
                        principalTable: "UserRole",
                        principalColumn: "Id_UserRole",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id_UserRole", "ChangeUserRole", "ManageUserList", "Title", "WorkWithHierarchy" },
                values: new object[] { 1, true, true, "admin", true });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id_UserRole", "ChangeUserRole", "ManageUserList", "Title", "WorkWithHierarchy" },
                values: new object[] { 2, false, false, "dephead", true });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id_UserRole", "ChangeUserRole", "ManageUserList", "Title", "WorkWithHierarchy" },
                values: new object[] { 3, false, false, "employee", false });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id_User", "Birthdate", "Email", "FirstName", "IdUserRole", "LastName", "NotificationPermission", "Password", "RefreshToken", "RegisterDate" },
                values: new object[] { 1, new DateTime(2000, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Volodymyr", 1, "Kulchytskyi", true, "B9-0F-FB-AD-D6-FA-0E-AC-C1-47-1E-57-5F-E9-C7-B1", "admin", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id_User", "Birthdate", "Email", "FirstName", "IdUserRole", "LastName", "NotificationPermission", "Password", "RefreshToken", "RegisterDate" },
                values: new object[] { 2, new DateTime(2000, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "dephead@gamil.com", "Liubomyr", 2, "Skalskyi", true, "B9-0F-FB-AD-D6-FA-0E-AC-C1-47-1E-57-5F-E9-C7-B1", "dephead", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id_User", "Birthdate", "Email", "FirstName", "IdUserRole", "LastName", "NotificationPermission", "Password", "RefreshToken", "RegisterDate" },
                values: new object[] { 3, new DateTime(2000, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "employee@gmail.com", "Andrii", 3, "Salii", true, "B9-0F-FB-AD-D6-FA-0E-AC-C1-47-1E-57-5F-E9-C7-B1", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_User_IdUserRole",
                table: "User",
                column: "IdUserRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
