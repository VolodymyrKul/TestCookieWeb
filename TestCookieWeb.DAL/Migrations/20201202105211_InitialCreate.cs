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
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id_Comment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_User = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKComment", x => x.Id_Comment);
                    table.ForeignKey(
                        name: "R_15",
                        column: x => x.Id_User,
                        principalTable: "User",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id_Department = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    IdDepHead = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKDepartment", x => x.Id_Department);
                    table.ForeignKey(
                        name: "R_16",
                        column: x => x.IdDepHead,
                        principalTable: "User",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id_Notification = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Read = table.Column<bool>(type: "bit", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKNotification", x => x.Id_Notification);
                    table.ForeignKey(
                        name: "R_19",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id_Request = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    CreateData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PrevStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NotApproveUsers = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKRequest", x => x.Id_Request);
                    table.ForeignKey(
                        name: "R_20",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentUser",
                columns: table => new
                {
                    Id_DepartmentUser = table.Column<int>(name: "Id_ DepartmentUser", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDepartment = table.Column<int>(type: "int", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKDepartmentUser", x => x.Id_DepartmentUser);
                    table.ForeignKey(
                        name: "R_17",
                        column: x => x.IdDepartment,
                        principalTable: "Department",
                        principalColumn: "Id_Department",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_18",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRequest",
                columns: table => new
                {
                    Id_UserRequest = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdApproveUser = table.Column<int>(type: "int", nullable: true),
                    IdRequest = table.Column<int>(type: "int", nullable: true),
                    IdComment = table.Column<int>(type: "int", nullable: true),
                    ApproveStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKUserRequest", x => x.Id_UserRequest);
                    table.ForeignKey(
                        name: "R_22",
                        column: x => x.IdApproveUser,
                        principalTable: "User",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_23",
                        column: x => x.IdComment,
                        principalTable: "Comment",
                        principalColumn: "Id_Comment",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_24",
                        column: x => x.IdRequest,
                        principalTable: "Request",
                        principalColumn: "Id_Request",
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
                values: new object[,]
                {
                    { 1, new DateTime(2000, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Volodymyr", 1, "Kulchytskyi", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "admin", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, new DateTime(2000, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "rudenkooleh@gmail.com", "Oleh", 3, "Rudenko", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, new DateTime(2000, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "lysenkodmyt@gmail.com", "Dmytro", 3, "Lysenko", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, new DateTime(2000, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "marchenkoihor@gmail.com", "Ihor", 3, "Marchenko", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new DateTime(2000, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "morozvital@gmail.com", "Vitalii", 3, "Moroz", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new DateTime(2000, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "tkachukhryh@gmail.com", "Hryhorii", 3, "Tkachuk", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(2000, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "bondarolek@gmail.com", "Oleksii", 3, "Bondar", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(2000, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "polishchukand@gmail.com", "Andrii", 3, "Polishchuk", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(2000, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "kovalyur@gmail.com", "Yurii", 3, "Koval", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(2000, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "shevchukpet@gmail.com", "Petro", 3, "Shevchuk", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2000, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "oliinykmykh@gmail.com", "Mykhailo", 3, "Oliinyk", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2000, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "kravchenkoanat@gmail.com", "Anatolii", 3, "Kravchenko", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2000, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kovalchukvik@gmail.com", "Viktor", 3, "Kovalchuk", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2000, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "tkachenkoser@gmail.com", "Serhii", 3, "Tkachenko", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, new DateTime(2000, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "savchenkoval@gmail.com", "Valerii", 3, "Savchenko", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2000, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "bondarenkovas@gmail.com", "Vasyl", 3, "Bondarenko", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, new DateTime(2000, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "horakihor@gmail.com", "Ihor", 2, "Horak", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "kernytskyiost@gmail.com", "Ostap", 2, "Kernytskyi", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, new DateTime(2000, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "krysavas@gmail.com", "Vasyl", 2, "Krysa", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2000, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "boikoolek@gmail.com", "Oleksandr", 2, "Boiko", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2000, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "shevchenkovol@gmail.com", "Volodymyr", 2, "Shevchenko", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2000, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "melnykmyk@gmail.com", "Mykola", 2, "Melnyk", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2000, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "hladyoandr@gmail.com", "Andrii", 2, "Hlado", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2000, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "pynzynyura@gmail.com", "Yurii", 2, "Pynzyn", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2000, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "stasenoleks@gmail.com", "Oleksandr", 2, "Stasenko", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2000, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "turyanmykh@gmail.com", "Mykhailo", 2, "Turianskyi", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2000, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ilivocs@gmail.com", "Oksana", 2, "Iliv", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2000, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "saliiAndr@gmail.com", "Andrii", 2, "Salii", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2000, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "skalskyiliub@gamil.com", "Liubomyr", 2, "Skalskyi", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "dephead", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2000, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kovalenkoiv@gmail.com", "Ivan", 3, "Kovalenko", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, new DateTime(2000, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "petrenkoleo@gmail.com", "Leonid", 3, "Petrenko", true, "9D58B6120CF9D51DB7EBD89CFA2FF669", "employee", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id_Comment", "CreateDate", "Description", "Id_User", "Title" },
                values: new object[] { 1, new DateTime(2000, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Base comment form admin, when somebody created new request", 1, "Request did not comment" });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id_Department", "Description", "IdDepHead", "Title" },
                values: new object[,]
                {
                    { 9, "Make frontend on VueJS", 11, "VueJS_Dep" },
                    { 8, "Make frontend on React", 10, "React_Dep" },
                    { 7, "Make frontend on Angular", 9, "Angular_Dep" },
                    { 6, "Make mobile app on Java", 8, "Java_Dep" },
                    { 5, "Make mobile app on Xamarin", 7, "Xamarin_Dep" },
                    { 4, "Make mobile app on Kotlin", 6, "Kotlin_Dep" },
                    { 3, "Make backend on C++", 5, "C++_Dep" },
                    { 1, "Make backend on Python", 4, "Python_Dep" },
                    { 11, "Make frontend to apps", 30, "Frontend_Dep" },
                    { 12, "Make mobile apps", 3, "Mobile_Dep" },
                    { 13, "Make different apps", 29, "Dev_Dep" },
                    { 10, "Make backend to apps", 2, "Backend_Dep" },
                    { 2, "Make backend on C#", 31, "C#_Dep" }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id_Notification", "Description", "IdUser", "Read", "Title" },
                values: new object[,]
                {
                    { 20, "User 18 create new request", 30, false, "New request for approving" },
                    { 6, "User 13 create new request", 29, false, "New request for approving" },
                    { 9, "User 14 create new request", 29, false, "New request for approving" },
                    { 58, "User 14 create new request", 31, false, "New request for approving" },
                    { 15, "User 16 create new request", 29, false, "New request for approving" },
                    { 18, "User 17 create new request", 29, false, "New request for approving" },
                    { 10, "User 15 create new request", 31, false, "New request for approving" },
                    { 21, "User 18 create new request", 29, false, "New request for approving" },
                    { 7, "User 14 create new request", 31, false, "New request for approving" },
                    { 24, "User 19 create new request", 29, false, "New request for approving" },
                    { 27, "User 20 create new request", 29, false, "New request for approving" },
                    { 30, "User 21 create new request", 29, false, "New request for approving" },
                    { 33, "User 22 create new request", 29, false, "New request for approving" },
                    { 35, "User 23 create new request", 30, false, "New request for approving" },
                    { 36, "User 23 create new request", 29, false, "New request for approving" },
                    { 39, "User 24 create new request", 29, false, "New request for approving" },
                    { 32, "User 22 create new request", 30, false, "New request for approving" },
                    { 42, "User 25 create new request", 29, false, "New request for approving" },
                    { 3, "User 12 create new request", 29, false, "New request for approving" },
                    { 48, "User 27 create new request", 29, false, "New request for approving" },
                    { 51, "User 28 create new request", 29, false, "New request for approving" },
                    { 29, "User 21 create new request", 30, false, "New request for approving" },
                    { 54, "User 12 create new request", 29, false, "New request for approving" },
                    { 57, "User 13 create new request", 29, false, "New request for approving" },
                    { 60, "User 14 create new request", 29, false, "New request for approving" },
                    { 26, "User 20 create new request", 30, false, "New request for approving" },
                    { 23, "User 19 create new request", 30, false, "New request for approving" },
                    { 45, "User 26 create new request", 29, false, "New request for approving" }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id_Notification", "Description", "IdUser", "Read", "Title" },
                values: new object[,]
                {
                    { 12, "User 15 create new request", 29, false, "New request for approving" },
                    { 31, "User 22 create new request", 11, false, "New request for approving" },
                    { 2, "User 12 create new request", 2, false, "New request for approving" },
                    { 5, "User 13 create new request", 2, false, "New request for approving" },
                    { 8, "User 14 create new request", 2, false, "New request for approving" },
                    { 11, "User 15 create new request", 2, false, "New request for approving" },
                    { 14, "User 16 create new request", 2, false, "New request for approving" },
                    { 34, "User 23 create new request", 11, false, "New request for approving" },
                    { 53, "User 12 create new request", 2, false, "New request for approving" },
                    { 56, "User 13 create new request", 2, false, "New request for approving" },
                    { 59, "User 14 create new request", 2, false, "New request for approving" },
                    { 38, "User 24 create new request", 3, false, "New request for approving" },
                    { 41, "User 25 create new request", 3, false, "New request for approving" },
                    { 44, "User 26 create new request", 3, false, "New request for approving" },
                    { 47, "User 27 create new request", 3, false, "New request for approving" },
                    { 50, "User 28 create new request", 3, false, "New request for approving" },
                    { 1, "User 12 create new request", 4, false, "New request for approving" },
                    { 17, "User 17 create new request", 2, false, "New request for approving" },
                    { 52, "User 12 create new request", 4, false, "New request for approving" },
                    { 28, "User 21 create new request", 10, false, "New request for approving" },
                    { 25, "User 20 create new request", 10, false, "New request for approving" },
                    { 22, "User 19 create new request", 9, false, "New request for approving" },
                    { 19, "User 18 create new request", 9, false, "New request for approving" },
                    { 46, "User 27 create new request", 7, false, "New request for approving" },
                    { 49, "User 28 create new request", 8, false, "New request for approving" },
                    { 40, "User 25 create new request", 6, false, "New request for approving" },
                    { 37, "User 24 create new request", 6, false, "New request for approving" },
                    { 16, "User 17 create new request", 5, false, "New request for approving" },
                    { 13, "User 16 create new request", 5, false, "New request for approving" },
                    { 55, "User 13 create new request", 4, false, "New request for approving" },
                    { 43, "User 26 create new request", 7, false, "New request for approving" },
                    { 4, "User 13 create new request", 4, false, "New request for approving" }
                });

            migrationBuilder.InsertData(
                table: "Request",
                columns: new[] { "Id_Request", "CreateData", "Description", "EndDate", "IdUser", "NotApproveUsers", "PrevStatus", "Price", "Status", "Title" },
                values: new object[,]
                {
                    { 11, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Swift Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 3, "Not approved 3 users", 900f, "Not approved 3 users", "Swift Request" },
                    { 9, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for TS Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 3, "Not approved 3 users", 900f, "Not approved 3 users", "TS Request" },
                    { 10, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Kotlin Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 3, "Not approved 3 users", 1000f, "Not approved 3 users", "Kotlin Request" },
                    { 15, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for SQL Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 3, "Not approved 3 users", 500f, "Not approved 3 users", "SQL Request" },
                    { 13, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for PHP Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 3, "Not approved 3 users", 700f, "Not approved 3 users", "PHP Request" },
                    { 14, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for R Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 3, "Not approved 3 users", 600f, "Not approved 3 users", "R Request" },
                    { 8, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for JS Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 3, "Not approved 3 users", 800f, "Not approved 3 users", "JS Request" },
                    { 12, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Perl Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 3, "Not approved 3 users", 800f, "Not approved 3 users", "Perl Request" },
                    { 7, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Scala Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 3, "Not approved 3 users", 700f, "Not approved 3 users", "Scala Request" },
                    { 2, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for C++ Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 3, "Not approved 3 users", 200f, "Not approved 3 users", "C++ Request" }
                });

            migrationBuilder.InsertData(
                table: "Request",
                columns: new[] { "Id_Request", "CreateData", "Description", "EndDate", "IdUser", "NotApproveUsers", "PrevStatus", "Price", "Status", "Title" },
                values: new object[,]
                {
                    { 5, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for C Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 3, "Not approved 3 users", 500f, "Not approved 3 users", "C Request" },
                    { 4, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Python Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 3, "Not approved 3 users", 400f, "Not approved 3 users", "Python Request" },
                    { 20, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Pascal Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 3, "Not approved 3 users", 100f, "Not approved 3 users", "Pascal Request" },
                    { 3, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Java Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 3, "Not approved 3 users", 300f, "Not approved 3 users", "Java Request" },
                    { 19, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Delphi Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 3, "Not approved 3 users", 100f, "Not approved 3 users", "Delphi Request" },
                    { 18, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Matlab Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 3, "Not approved 3 users", 200f, "Not approved 3 users", "Matlab Request" },
                    { 1, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for C# Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 3, "Not approved 3 users", 100f, "Not approved 3 users", "C# Request" },
                    { 16, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for GO Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 3, "Not approved 3 users", 400f, "Not approved 3 users", "GO Request" },
                    { 6, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Ruby Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 3, "Not approved 3 users", 600f, "Not approved 3 users", "Ruby Request" },
                    { 17, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Dart Request", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 3, "Not approved 3 users", 300f, "Not approved 3 users", "Dart Request" }
                });

            migrationBuilder.InsertData(
                table: "DepartmentUser",
                columns: new[] { "Id_ DepartmentUser", "IdDepartment", "IdUser" },
                values: new object[,]
                {
                    { 18, 10, 4 },
                    { 3, 2, 14 },
                    { 23, 11, 11 },
                    { 22, 11, 10 },
                    { 21, 11, 9 },
                    { 29, 13, 3 },
                    { 28, 13, 30 },
                    { 27, 13, 2 },
                    { 17, 9, 28 },
                    { 16, 8, 27 },
                    { 15, 8, 26 },
                    { 14, 7, 25 },
                    { 13, 7, 24 },
                    { 12, 6, 23 },
                    { 4, 2, 15 },
                    { 10, 5, 21 },
                    { 11, 6, 22 },
                    { 19, 10, 31 },
                    { 20, 10, 5 },
                    { 24, 12, 6 },
                    { 26, 12, 8 },
                    { 1, 1, 12 },
                    { 25, 12, 7 },
                    { 5, 3, 16 },
                    { 6, 3, 17 },
                    { 7, 4, 18 },
                    { 8, 4, 19 },
                    { 9, 5, 20 },
                    { 2, 1, 13 }
                });

            migrationBuilder.InsertData(
                table: "UserRequest",
                columns: new[] { "Id_UserRequest", "ApproveStatus", "IdApproveUser", "IdComment", "IdRequest" },
                values: new object[,]
                {
                    { 30, false, 29, 1, 10 },
                    { 33, false, 29, 1, 11 },
                    { 32, false, 30, 1, 11 },
                    { 31, false, 11, 1, 11 },
                    { 29, false, 30, 1, 10 },
                    { 23, false, 30, 1, 8 },
                    { 27, false, 29, 1, 9 },
                    { 26, false, 30, 1, 9 },
                    { 25, false, 10, 1, 9 },
                    { 24, false, 29, 1, 8 },
                    { 34, false, 11, 1, 12 },
                    { 28, false, 10, 1, 10 },
                    { 35, false, 30, 1, 12 }
                });

            migrationBuilder.InsertData(
                table: "UserRequest",
                columns: new[] { "Id_UserRequest", "ApproveStatus", "IdApproveUser", "IdComment", "IdRequest" },
                values: new object[,]
                {
                    { 42, false, 29, 1, 14 },
                    { 37, false, 6, 1, 13 },
                    { 38, false, 3, 1, 13 },
                    { 39, false, 29, 1, 13 },
                    { 40, false, 6, 1, 14 },
                    { 41, false, 3, 1, 14 },
                    { 43, false, 7, 1, 15 },
                    { 44, false, 3, 1, 15 },
                    { 45, false, 29, 1, 15 },
                    { 46, false, 7, 1, 16 },
                    { 47, false, 3, 1, 16 },
                    { 48, false, 29, 1, 16 },
                    { 49, false, 8, 1, 17 },
                    { 22, false, 9, 1, 8 },
                    { 36, false, 29, 1, 12 },
                    { 21, false, 29, 1, 7 },
                    { 58, false, 31, 1, 20 },
                    { 19, false, 9, 1, 7 },
                    { 1, false, 4, 1, 1 },
                    { 2, false, 2, 1, 1 },
                    { 3, false, 29, 1, 1 },
                    { 52, false, 4, 1, 18 },
                    { 53, false, 2, 1, 18 },
                    { 54, false, 29, 1, 18 },
                    { 4, false, 4, 1, 2 },
                    { 5, false, 2, 1, 2 },
                    { 6, false, 29, 1, 2 },
                    { 55, false, 4, 1, 19 },
                    { 56, false, 2, 1, 19 },
                    { 57, false, 29, 1, 19 },
                    { 7, false, 31, 1, 3 },
                    { 8, false, 2, 1, 3 },
                    { 9, false, 29, 1, 3 },
                    { 50, false, 3, 1, 17 },
                    { 59, false, 2, 1, 20 },
                    { 60, false, 29, 1, 20 },
                    { 10, false, 31, 1, 4 },
                    { 11, false, 2, 1, 4 },
                    { 12, false, 29, 1, 4 },
                    { 13, false, 5, 1, 5 },
                    { 14, false, 2, 1, 5 },
                    { 15, false, 29, 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "UserRequest",
                columns: new[] { "Id_UserRequest", "ApproveStatus", "IdApproveUser", "IdComment", "IdRequest" },
                values: new object[,]
                {
                    { 16, false, 5, 1, 6 },
                    { 17, false, 2, 1, 6 },
                    { 18, false, 29, 1, 6 },
                    { 20, false, 30, 1, 7 },
                    { 51, false, 29, 1, 17 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Id_User",
                table: "Comment",
                column: "Id_User");

            migrationBuilder.CreateIndex(
                name: "IX_Department_IdDepHead",
                table: "Department",
                column: "IdDepHead");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentUser_IdDepartment",
                table: "DepartmentUser",
                column: "IdDepartment");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentUser_IdUser",
                table: "DepartmentUser",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_IdUser",
                table: "Notification",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Request_IdUser",
                table: "Request",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdUserRole",
                table: "User",
                column: "IdUserRole");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequest_IdApproveUser",
                table: "UserRequest",
                column: "IdApproveUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequest_IdComment",
                table: "UserRequest",
                column: "IdComment");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequest_IdRequest",
                table: "UserRequest",
                column: "IdRequest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentUser");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "UserRequest");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
