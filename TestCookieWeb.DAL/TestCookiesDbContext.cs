using CryptoHelper;
using Microsoft.EntityFrameworkCore;
using System;
using TestCookieWeb.Core.Models;
using TestCookieWeb.Services.Helpers;

namespace TestCookieWeb.DAL
{
    public class TestCookiesDbContext : DbContext
    {
        public TestCookiesDbContext()
        {
        }

        public TestCookiesDbContext(DbContextOptions<TestCookiesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(
                    "Data Source=DESKTOP-THTGA2V;Initial Catalog=TestCookieDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKUser");

                entity.Property(e => e.Id)
                .HasColumnName("Id_User");

                entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.HasOne(d => d.IdUserRoleNavigation)
                .WithMany(p => p.User)
                .HasForeignKey(d => d.IdUserRole)
                .HasConstraintName("R_21");

                entity.HasData(
                    new User
                    {
                        Id = 1,
                        FirstName = "Volodymyr",
                        LastName = "Kulchytskyi",
                        Email = "admin@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "admin",
                        Birthdate = new DateTime(2000, 8, 11),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 1
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Liubomyr",
                        LastName = "Skalskyi",
                        Email = "skalskyiliub@gamil.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "dephead",
                        Birthdate = new DateTime(2000, 10, 13),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 2
                    },
                    new User
                    {
                        Id = 3,
                        FirstName = "Andrii",
                        LastName = "Salii",
                        Email = "saliiAndr@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 12, 15),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 2
                    },
                    new User
                    {
                        Id = 4,
                        FirstName = "Oksana",
                        LastName = "Iliv",
                        Email = "ilivocs@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 2, 17),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 2
                    },
                    new User
                    {
                        Id = 5,
                        FirstName = "Mykhailo",
                        LastName = "Turianskyi",
                        Email = "turyanmykh@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 4, 19),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 2
                    },
                    new User
                    {
                        Id = 6,
                        FirstName = "Oleksandr",
                        LastName = "Stasenko",
                        Email = "stasenoleks@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 6, 21),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 2
                    },
                    new User
                    {
                        Id = 7,
                        FirstName = "Yurii",
                        LastName = "Pynzyn",
                        Email = "pynzynyura@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 9, 23),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 2
                    },
                    new User
                    {
                        Id = 8,
                        FirstName = "Andrii",
                        LastName = "Hlado",
                        Email = "hladyoandr@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 11, 25),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 2
                    },
                    new User
                    {
                        Id = 9,
                        FirstName = "Mykola",
                        LastName = "Melnyk",
                        Email = "melnykmyk@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 1, 27),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 2
                    },
                    new User
                    {
                        Id = 10,
                        FirstName = "Volodymyr",
                        LastName = "Shevchenko",
                        Email = "shevchenkovol@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 3, 29),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 2
                    },
                    new User
                    {
                        Id = 11,
                        FirstName = "Oleksandr",
                        LastName = "Boiko",
                        Email = "boikoolek@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 5, 31),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 2
                    },
                    new User
                    {
                        Id = 12,
                        FirstName = "Ivan",
                        LastName = "Kovalenko",
                        Email = "kovalenkoiv@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 7, 1),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
                    },
                    new User
                    {
                        Id = 13,
                        FirstName = "Vasyl",
                        LastName = "Bondarenko",
                        Email = "bondarenkovas@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 10, 3),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
                    },
                    new User
                    {
                        Id = 14,
                        FirstName = "Serhii",
                        LastName = "Tkachenko",
                        Email = "tkachenkoser@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 12, 5),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
                    },
                    new User
                    {
                        Id = 15,
                        FirstName = "Viktor",
                        LastName = "Kovalchuk",
                        Email = "kovalchukvik@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 2, 7),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
                    },
                    new User
                    {
                        Id = 16,
                        FirstName = "Anatolii",
                        LastName = "Kravchenko",
                        Email = "kravchenkoanat@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 4, 9),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
                    },
                    new User
                    {
                        Id = 17,
                        FirstName = "Mykhailo",
                        LastName = "Oliinyk",
                        Email = "oliinykmykh@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 6, 12),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
                    },
                    new User
                    {
                        Id = 18,
                        FirstName = "Petro",
                        LastName = "Shevchuk",
                        Email = "shevchukpet@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 8, 14),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
                    },
                    new User
                    {
                        Id = 19,
                        FirstName = "Yurii",
                        LastName = "Koval",
                        Email = "kovalyur@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 11, 16),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
                    },
                    new User
                    {
                        Id = 20,
                        FirstName = "Andrii",
                        LastName = "Polishchuk",
                        Email = "polishchukand@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 1, 18),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
                    },
                    new User
                    {
                        Id = 21,
                        FirstName = "Oleksii",
                        LastName = "Bondar",
                        Email = "bondarolek@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 3, 20),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
                    },
                    new User
                    {
                        Id = 22,
                        FirstName = "Hryhorii",
                        LastName = "Tkachuk",
                        Email = "tkachukhryh@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 5, 22),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
                    },
                    new User
                    {
                        Id = 23,
                        FirstName = "Vitalii",
                        LastName = "Moroz",
                        Email = "morozvital@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 7, 24),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
                    },
                    new User
                    {
                        Id = 24,
                        FirstName = "Ihor",
                        LastName = "Marchenko",
                        Email = "marchenkoihor@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 9, 26),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
                    },
                    new User
                    {
                        Id = 25,
                        FirstName = "Dmytro",
                        LastName = "Lysenko",
                        Email = "lysenkodmyt@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 12, 28),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
                    },
                    new User
                    {
                        Id = 26,
                        FirstName = "Oleh",
                        LastName = "Rudenko",
                        Email = "rudenkooleh@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 2, 2),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
                    },
                    new User
                    {
                        Id = 27,
                        FirstName = "Valerii",
                        LastName = "Savchenko",
                        Email = "savchenkoval@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 4, 4),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
                    },
                    new User
                    {
                        Id = 28,
                        FirstName = "Leonid",
                        LastName = "Petrenko",
                        Email = "petrenkoleo@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 6, 6),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
                    },
                    new User
                    {
                        Id = 29,
                        FirstName = "Vasyl",
                        LastName = "Krysa",
                        Email = "krysavas@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 8, 8),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 2
                    },
                    new User
                    {
                        Id = 30,
                        FirstName = "Ostap",
                        LastName = "Kernytskyi",
                        Email = "kernytskyiost@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 10, 10),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 2
                    },
                    new User
                    {
                        Id = 31,
                        FirstName = "Ihor",
                        LastName = "Horak",
                        Email = "horakihor@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 1, 12),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 2
                    });
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKUserRole");

                entity.Property(e => e.Id)
                .HasColumnName("Id_UserRole");


                entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.HasData(
                    new UserRole
                    {
                        Id = 1,
                        Title = "admin",
                        ChangeUserRole = true,
                        ManageUserList = true,
                        WorkWithHierarchy = true
                    },
                    new UserRole
                    {
                        Id = 2,
                        Title = "dephead",
                        ChangeUserRole = false,
                        ManageUserList = false,
                        WorkWithHierarchy = true
                    },
                    new UserRole
                    {
                        Id = 3,
                        Title = "employee",
                        ChangeUserRole = false,
                        ManageUserList = false,
                        WorkWithHierarchy = false
                    });
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKComment");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Comment");

                entity.Property(e => e.IdUser)
                .HasColumnName("Id_User");

                entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.Comment)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("R_15");

                entity.HasData(
                    new Comment { 
                        Id=1,
                        Title="Request did not comment",
                        Description="Base comment form admin, when somebody created new request",
                        CreateDate=new DateTime(2000,8,8),
                        IdUser=1
                    });
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKDepartment");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Department");

                entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);

                entity.HasOne(d => d.IdDepHeadNavigation)
                .WithMany(p => p.Department)
                .HasForeignKey(d => d.IdDepHead)
                .HasConstraintName("R_16");

                entity.HasData(
                    new Department
                    {
                        Id = 1,
                        Title = "Python_Dep",
                        Description = "Make backend on Python",
                        IdDepHead = 4
                    },
                    new Department
                    {
                        Id = 2,
                        Title = "C#_Dep",
                        Description = "Make backend on C#",
                        IdDepHead = 31
                    },
                    new Department
                    {
                        Id = 3,
                        Title = "C++_Dep",
                        Description = "Make backend on C++",
                        IdDepHead = 5
                    },
                    new Department
                    {
                        Id = 4,
                        Title = "Kotlin_Dep",
                        Description = "Make mobile app on Kotlin",
                        IdDepHead = 6
                    },
                    new Department
                    {
                        Id = 5,
                        Title = "Xamarin_Dep",
                        Description = "Make mobile app on Xamarin",
                        IdDepHead = 7
                    },
                    new Department
                    {
                        Id = 6,
                        Title = "Java_Dep",
                        Description = "Make mobile app on Java",
                        IdDepHead = 8
                    },
                    new Department
                    {
                        Id = 7,
                        Title = "Angular_Dep",
                        Description = "Make frontend on Angular",
                        IdDepHead = 9
                    },
                    new Department
                    {
                        Id = 8,
                        Title = "React_Dep",
                        Description = "Make frontend on React",
                        IdDepHead = 10
                    },
                    new Department
                    {
                        Id = 9,
                        Title = "VueJS_Dep",
                        Description = "Make frontend on VueJS",
                        IdDepHead = 11
                    },
                    new Department
                    {
                        Id = 10,
                        Title = "Backend_Dep",
                        Description = "Make backend to apps",
                        IdDepHead = 2
                    },
                    new Department
                    {
                        Id = 11,
                        Title = "Frontend_Dep",
                        Description = "Make frontend to apps",
                        IdDepHead = 30
                    },
                    new Department
                    {
                        Id = 12,
                        Title = "Mobile_Dep",
                        Description = "Make mobile apps",
                        IdDepHead = 3
                    },
                    new Department
                    {
                        Id = 13,
                        Title = "Dev_Dep",
                        Description = "Make different apps",
                        IdDepHead = 29
                    });
            });

            modelBuilder.Entity<DepartmentUser>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKDepartmentUser");

                entity.Property(e => e.Id)
                .HasColumnName("Id_ DepartmentUser");

                entity.HasOne(d => d.IdDepartmentNavigation)
                .WithMany(p => p.DepartmentUser)
                .HasForeignKey(d => d.IdDepartment)
                .HasConstraintName("R_17");

                entity.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.DepartmentUser)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("R_18");

                entity.HasData(
                    new DepartmentUser
                    {
                        Id = 1,
                        IdDepartment = 1,
                        IdUser = 12
                    },
                    new DepartmentUser
                    {
                        Id = 2,
                        IdDepartment = 1,
                        IdUser = 13
                    },
                    new DepartmentUser
                    {
                        Id = 3,
                        IdDepartment = 2,
                        IdUser = 14
                    },
                    new DepartmentUser
                    {
                        Id = 4,
                        IdDepartment = 2,
                        IdUser = 15
                    },
                    new DepartmentUser
                    {
                        Id = 5,
                        IdDepartment = 3,
                        IdUser = 16
                    },
                    new DepartmentUser
                    {
                        Id = 6,
                        IdDepartment = 3,
                        IdUser = 17
                    },
                    new DepartmentUser
                    {
                        Id = 7,
                        IdDepartment = 4,
                        IdUser = 18
                    },
                    new DepartmentUser
                    {
                        Id = 8,
                        IdDepartment = 4,
                        IdUser = 19
                    },
                    new DepartmentUser
                    {
                        Id = 9,
                        IdDepartment = 5,
                        IdUser = 20
                    },
                    new DepartmentUser
                    {
                        Id = 10,
                        IdDepartment = 5,
                        IdUser = 21
                    },
                    new DepartmentUser
                    {
                        Id = 11,
                        IdDepartment = 6,
                        IdUser = 22
                    },
                    new DepartmentUser
                    {
                        Id = 12,
                        IdDepartment = 6,
                        IdUser = 23
                    },
                    new DepartmentUser
                    {
                        Id = 13,
                        IdDepartment = 7,
                        IdUser = 24
                    },
                    new DepartmentUser
                    {
                        Id = 14,
                        IdDepartment = 7,
                        IdUser = 25
                    },
                    new DepartmentUser
                    {
                        Id = 15,
                        IdDepartment = 8,
                        IdUser = 26
                    },
                    new DepartmentUser
                    {
                        Id = 16,
                        IdDepartment = 8,
                        IdUser = 27
                    },
                    new DepartmentUser
                    {
                        Id = 17,
                        IdDepartment = 9,
                        IdUser = 28
                    },
                    new DepartmentUser
                    {
                        Id = 18,
                        IdDepartment = 10,
                        IdUser = 4
                    },
                    new DepartmentUser
                    {
                        Id = 19,
                        IdDepartment = 10,
                        IdUser = 31
                    },
                    new DepartmentUser
                    {
                        Id = 20,
                        IdDepartment = 10,
                        IdUser = 5
                    },
                    new DepartmentUser
                    {
                        Id = 21,
                        IdDepartment = 11,
                        IdUser = 9
                    },
                    new DepartmentUser
                    {
                        Id = 22,
                        IdDepartment = 11,
                        IdUser = 10
                    },
                    new DepartmentUser
                    {
                        Id = 23,
                        IdDepartment = 11,
                        IdUser = 11
                    },
                    new DepartmentUser
                    {
                        Id = 24,
                        IdDepartment = 12,
                        IdUser = 6
                    },
                    new DepartmentUser
                    {
                        Id = 25,
                        IdDepartment = 12,
                        IdUser = 7
                    },
                    new DepartmentUser
                    {
                        Id = 26,
                        IdDepartment = 12,
                        IdUser = 8
                    },
                    new DepartmentUser
                    {
                        Id = 27,
                        IdDepartment = 13,
                        IdUser = 2
                    },
                    new DepartmentUser
                    {
                        Id = 28,
                        IdDepartment = 13,
                        IdUser = 30
                    },
                    new DepartmentUser
                    {
                        Id = 29,
                        IdDepartment = 13,
                        IdUser = 3
                    });
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKNotification");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Notification");

                entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.Notification)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("R_19");

                entity.HasData(
                    new Notification
                    {
                        Id=1,
                        Title="New request for approving",
                        Description="User 12 create new request",
                        Read=false,
                        IdUser=4
                    },
                    new Notification
                    {
                        Id = 2,
                        Title = "New request for approving",
                        Description = "User 12 create new request",
                        Read = false,
                        IdUser = 2
                    },
                    new Notification
                    {
                        Id = 3,
                        Title = "New request for approving",
                        Description = "User 12 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 4,
                        Title = "New request for approving",
                        Description = "User 13 create new request",
                        Read = false,
                        IdUser = 4
                    },
                    new Notification
                    {
                        Id = 5,
                        Title = "New request for approving",
                        Description = "User 13 create new request",
                        Read = false,
                        IdUser = 2
                    },
                    new Notification
                    {
                        Id = 6,
                        Title = "New request for approving",
                        Description = "User 13 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 7,
                        Title = "New request for approving",
                        Description = "User 14 create new request",
                        Read = false,
                        IdUser = 31
                    },
                    new Notification
                    {
                        Id = 8,
                        Title = "New request for approving",
                        Description = "User 14 create new request",
                        Read = false,
                        IdUser = 2
                    },
                    new Notification
                    {
                        Id = 9,
                        Title = "New request for approving",
                        Description = "User 14 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 10,
                        Title = "New request for approving",
                        Description = "User 15 create new request",
                        Read = false,
                        IdUser = 31
                    },
                    new Notification
                    {
                        Id = 11,
                        Title = "New request for approving",
                        Description = "User 15 create new request",
                        Read = false,
                        IdUser = 2
                    },
                    new Notification
                    {
                        Id = 12,
                        Title = "New request for approving",
                        Description = "User 15 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 13,
                        Title = "New request for approving",
                        Description = "User 16 create new request",
                        Read = false,
                        IdUser = 5
                    },
                    new Notification
                    {
                        Id = 14,
                        Title = "New request for approving",
                        Description = "User 16 create new request",
                        Read = false,
                        IdUser = 2
                    },
                    new Notification
                    {
                        Id = 15,
                        Title = "New request for approving",
                        Description = "User 16 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 16,
                        Title = "New request for approving",
                        Description = "User 17 create new request",
                        Read = false,
                        IdUser = 5
                    },
                    new Notification
                    {
                        Id = 17,
                        Title = "New request for approving",
                        Description = "User 17 create new request",
                        Read = false,
                        IdUser = 2
                    },
                    new Notification
                    {
                        Id = 18,
                        Title = "New request for approving",
                        Description = "User 17 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 19,
                        Title = "New request for approving",
                        Description = "User 18 create new request",
                        Read = false,
                        IdUser = 9
                    },
                    new Notification
                    {
                        Id = 20,
                        Title = "New request for approving",
                        Description = "User 18 create new request",
                        Read = false,
                        IdUser = 30
                    },
                    new Notification
                    {
                        Id = 21,
                        Title = "New request for approving",
                        Description = "User 18 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 22,
                        Title = "New request for approving",
                        Description = "User 19 create new request",
                        Read = false,
                        IdUser = 9
                    },
                    new Notification
                    {
                        Id = 23,
                        Title = "New request for approving",
                        Description = "User 19 create new request",
                        Read = false,
                        IdUser = 30
                    },
                    new Notification
                    {
                        Id = 24,
                        Title = "New request for approving",
                        Description = "User 19 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 25,
                        Title = "New request for approving",
                        Description = "User 20 create new request",
                        Read = false,
                        IdUser = 10
                    },
                    new Notification
                    {
                        Id = 26,
                        Title = "New request for approving",
                        Description = "User 20 create new request",
                        Read = false,
                        IdUser = 30
                    },
                    new Notification
                    {
                        Id = 27,
                        Title = "New request for approving",
                        Description = "User 20 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 28,
                        Title = "New request for approving",
                        Description = "User 21 create new request",
                        Read = false,
                        IdUser = 10
                    },
                    new Notification
                    {
                        Id = 29,
                        Title = "New request for approving",
                        Description = "User 21 create new request",
                        Read = false,
                        IdUser = 30
                    },
                    new Notification
                    {
                        Id = 30,
                        Title = "New request for approving",
                        Description = "User 21 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 31,
                        Title = "New request for approving",
                        Description = "User 22 create new request",
                        Read = false,
                        IdUser = 11
                    },
                    new Notification
                    {
                        Id = 32,
                        Title = "New request for approving",
                        Description = "User 22 create new request",
                        Read = false,
                        IdUser = 30
                    },
                    new Notification
                    {
                        Id = 33,
                        Title = "New request for approving",
                        Description = "User 22 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 34,
                        Title = "New request for approving",
                        Description = "User 23 create new request",
                        Read = false,
                        IdUser = 11
                    },
                    new Notification
                    {
                        Id = 35,
                        Title = "New request for approving",
                        Description = "User 23 create new request",
                        Read = false,
                        IdUser = 30
                    },
                    new Notification
                    {
                        Id = 36,
                        Title = "New request for approving",
                        Description = "User 23 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 37,
                        Title = "New request for approving",
                        Description = "User 24 create new request",
                        Read = false,
                        IdUser = 6
                    },
                    new Notification
                    {
                        Id = 38,
                        Title = "New request for approving",
                        Description = "User 24 create new request",
                        Read = false,
                        IdUser = 3
                    },
                    new Notification
                    {
                        Id = 39,
                        Title = "New request for approving",
                        Description = "User 24 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 40,
                        Title = "New request for approving",
                        Description = "User 25 create new request",
                        Read = false,
                        IdUser = 6
                    },
                    new Notification
                    {
                        Id = 41,
                        Title = "New request for approving",
                        Description = "User 25 create new request",
                        Read = false,
                        IdUser = 3
                    },
                    new Notification
                    {
                        Id = 42,
                        Title = "New request for approving",
                        Description = "User 25 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 43,
                        Title = "New request for approving",
                        Description = "User 26 create new request",
                        Read = false,
                        IdUser = 7
                    },
                    new Notification
                    {
                        Id = 44,
                        Title = "New request for approving",
                        Description = "User 26 create new request",
                        Read = false,
                        IdUser = 3
                    },
                    new Notification
                    {
                        Id = 45,
                        Title = "New request for approving",
                        Description = "User 26 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 46,
                        Title = "New request for approving",
                        Description = "User 27 create new request",
                        Read = false,
                        IdUser = 7
                    },
                    new Notification
                    {
                        Id = 47,
                        Title = "New request for approving",
                        Description = "User 27 create new request",
                        Read = false,
                        IdUser = 3
                    },
                    new Notification
                    {
                        Id = 48,
                        Title = "New request for approving",
                        Description = "User 27 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 49,
                        Title = "New request for approving",
                        Description = "User 28 create new request",
                        Read = false,
                        IdUser = 8
                    },
                    new Notification
                    {
                        Id = 50,
                        Title = "New request for approving",
                        Description = "User 28 create new request",
                        Read = false,
                        IdUser = 3
                    },
                    new Notification
                    {
                        Id = 51,
                        Title = "New request for approving",
                        Description = "User 28 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 52,
                        Title = "New request for approving",
                        Description = "User 12 create new request",
                        Read = false,
                        IdUser = 4
                    },
                    new Notification
                    {
                        Id = 53,
                        Title = "New request for approving",
                        Description = "User 12 create new request",
                        Read = false,
                        IdUser = 2
                    },
                    new Notification
                    {
                        Id = 54,
                        Title = "New request for approving",
                        Description = "User 12 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 55,
                        Title = "New request for approving",
                        Description = "User 13 create new request",
                        Read = false,
                        IdUser = 4
                    },
                    new Notification
                    {
                        Id = 56,
                        Title = "New request for approving",
                        Description = "User 13 create new request",
                        Read = false,
                        IdUser = 2
                    },
                    new Notification
                    {
                        Id = 57,
                        Title = "New request for approving",
                        Description = "User 13 create new request",
                        Read = false,
                        IdUser = 29
                    },
                    new Notification
                    {
                        Id = 58,
                        Title = "New request for approving",
                        Description = "User 14 create new request",
                        Read = false,
                        IdUser = 31
                    },
                    new Notification
                    {
                        Id = 59,
                        Title = "New request for approving",
                        Description = "User 14 create new request",
                        Read = false,
                        IdUser = 2
                    },
                    new Notification
                    {
                        Id = 60,
                        Title = "New request for approving",
                        Description = "User 14 create new request",
                        Read = false,
                        IdUser = 29
                    });
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKRequest");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Request");

                entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);

                entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.PrevStatus)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.Request)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("R_20");

                entity.HasData(
                    new Request { 
                        Id=1,
                        Title="C# Request",
                        Description= "Description for C# Request",
                        Price=100,
                        CreateData=new DateTime(2020, 8, 8),
                        EndDate=new DateTime(2021,8,8),
                        Status="Not approved 3 users",
                        PrevStatus="Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser=12
                    },
                    new Request
                    {
                        Id = 2,
                        Title = "C++ Request",
                        Description = "Description for C++ Request",
                        Price = 200,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 13
                    },
                    new Request
                    {
                        Id = 3,
                        Title = "Java Request",
                        Description = "Description for Java Request",
                        Price = 300,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 14
                    },
                    new Request
                    {
                        Id = 4,
                        Title = "Python Request",
                        Description = "Description for Python Request",
                        Price = 400,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 15
                    },
                    new Request
                    {
                        Id = 5,
                        Title = "C Request",
                        Description = "Description for C Request",
                        Price = 500,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 16
                    },
                    new Request
                    {
                        Id = 6,
                        Title = "Ruby Request",
                        Description = "Description for Ruby Request",
                        Price = 600,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 17
                    },
                    new Request
                    {
                        Id = 7,
                        Title = "Scala Request",
                        Description = "Description for Scala Request",
                        Price = 700,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 18
                    },
                    new Request
                    {
                        Id = 8,
                        Title = "JS Request",
                        Description = "Description for JS Request",
                        Price = 800,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 19
                    },
                    new Request
                    {
                        Id = 9,
                        Title = "TS Request",
                        Description = "Description for TS Request",
                        Price = 900,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 20
                    },
                    new Request
                    {
                        Id = 10,
                        Title = "Kotlin Request",
                        Description = "Description for Kotlin Request",
                        Price = 1000,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 21
                    },
                    new Request
                    {
                        Id = 11,
                        Title = "Swift Request",
                        Description = "Description for Swift Request",
                        Price = 900,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 22
                    },
                    new Request
                    {
                        Id = 12,
                        Title = "Perl Request",
                        Description = "Description for Perl Request",
                        Price = 800,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 23
                    },
                    new Request
                    {
                        Id = 13,
                        Title = "PHP Request",
                        Description = "Description for PHP Request",
                        Price = 700,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 24
                    },
                    new Request
                    {
                        Id = 14,
                        Title = "R Request",
                        Description = "Description for R Request",
                        Price = 600,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 25
                    },
                    new Request
                    {
                        Id = 15,
                        Title = "SQL Request",
                        Description = "Description for SQL Request",
                        Price = 500,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 26
                    },
                    new Request
                    {
                        Id = 16,
                        Title = "GO Request",
                        Description = "Description for GO Request",
                        Price = 400,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 27
                    },
                    new Request
                    {
                        Id = 17,
                        Title = "Dart Request",
                        Description = "Description for Dart Request",
                        Price = 300,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 28
                    },
                    new Request
                    {
                        Id = 18,
                        Title = "Matlab Request",
                        Description = "Description for Matlab Request",
                        Price = 200,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 12
                    },
                    new Request
                    {
                        Id = 19,
                        Title = "Delphi Request",
                        Description = "Description for Delphi Request",
                        Price = 100,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 13
                    },
                    new Request
                    {
                        Id = 20,
                        Title = "Pascal Request",
                        Description = "Description for Pascal Request",
                        Price = 100,
                        CreateData = new DateTime(2020, 8, 8),
                        EndDate = new DateTime(2021, 8, 8),
                        Status = "Not approved 3 users",
                        PrevStatus = "Not approved 3 users",
                        NotApproveUsers = 3,
                        IdUser = 14
                    });
            });

            modelBuilder.Entity<UserRequest>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKUserRequest");

                entity.Property(e => e.Id)
                .HasColumnName("Id_UserRequest");

                entity.HasOne(d => d.IdApproveUserNavigation)
                .WithMany(p => p.UserRequest)
                .HasForeignKey(d => d.IdApproveUser)
                .HasConstraintName("R_22");

                entity.HasOne(d => d.IdCommentNavigation)
                .WithMany(p => p.UserRequest)
                .HasForeignKey(d => d.IdComment)
                .HasConstraintName("R_23");

                entity.HasOne(d => d.IdRequestNavigation)
                .WithMany(p => p.UserRequest)
                .HasForeignKey(d => d.IdRequest)
                .HasConstraintName("R_24");

                entity.HasData(
                    new UserRequest
                    {
                        Id = 1,
                        IdApproveUser = 4,
                        IdRequest = 1,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 2,
                        IdApproveUser = 2,
                        IdRequest = 1,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 3,
                        IdApproveUser = 29,
                        IdRequest = 1,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 4,
                        IdApproveUser = 4,
                        IdRequest = 2,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 5,
                        IdApproveUser = 2,
                        IdRequest = 2,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 6,
                        IdApproveUser = 29,
                        IdRequest = 2,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 7,
                        IdApproveUser = 31,
                        IdRequest = 3,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 8,
                        IdApproveUser = 2,
                        IdRequest = 3,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 9,
                        IdApproveUser = 29,
                        IdRequest = 3,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 10,
                        IdApproveUser = 31,
                        IdRequest = 4,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 11,
                        IdApproveUser = 2,
                        IdRequest = 4,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 12,
                        IdApproveUser = 29,
                        IdRequest = 4,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 13,
                        IdApproveUser = 5,
                        IdRequest = 5,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 14,
                        IdApproveUser = 2,
                        IdRequest = 5,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 15,
                        IdApproveUser = 29,
                        IdRequest = 5,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 16,
                        IdApproveUser = 5,
                        IdRequest = 6,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 17,
                        IdApproveUser = 2,
                        IdRequest = 6,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 18,
                        IdApproveUser = 29,
                        IdRequest = 6,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 19,
                        IdApproveUser = 9,
                        IdRequest = 7,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 20,
                        IdApproveUser = 30,
                        IdRequest = 7,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 21,
                        IdApproveUser = 29,
                        IdRequest = 7,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 22,
                        IdApproveUser = 9,
                        IdRequest = 8,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 23,
                        IdApproveUser = 30,
                        IdRequest = 8,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 24,
                        IdApproveUser = 29,
                        IdRequest = 8,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 25,
                        IdApproveUser = 10,
                        IdRequest = 9,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 26,
                        IdApproveUser = 30,
                        IdRequest = 9,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 27,
                        IdApproveUser = 29,
                        IdRequest = 9,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 28,
                        IdApproveUser = 10,
                        IdRequest = 10,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 29,
                        IdApproveUser = 30,
                        IdRequest = 10,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 30,
                        IdApproveUser = 29,
                        IdRequest = 10,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 31,
                        IdApproveUser = 11,
                        IdRequest = 11,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 32,
                        IdApproveUser = 30,
                        IdRequest = 11,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 33,
                        IdApproveUser = 29,
                        IdRequest = 11,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 34,
                        IdApproveUser = 11,
                        IdRequest = 12,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 35,
                        IdApproveUser = 30,
                        IdRequest = 12,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 36,
                        IdApproveUser = 29,
                        IdRequest = 12,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 37,
                        IdApproveUser = 6,
                        IdRequest = 13,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 38,
                        IdApproveUser = 3,
                        IdRequest = 13,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 39,
                        IdApproveUser = 29,
                        IdRequest = 13,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 40,
                        IdApproveUser = 6,
                        IdRequest = 14,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 41,
                        IdApproveUser = 3,
                        IdRequest = 14,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 42,
                        IdApproveUser = 29,
                        IdRequest = 14,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 43,
                        IdApproveUser = 7,
                        IdRequest = 15,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 44,
                        IdApproveUser = 3,
                        IdRequest = 15,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 45,
                        IdApproveUser = 29,
                        IdRequest = 15,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 46,
                        IdApproveUser = 7,
                        IdRequest = 16,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 47,
                        IdApproveUser = 3,
                        IdRequest = 16,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 48,
                        IdApproveUser = 29,
                        IdRequest = 16,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 49,
                        IdApproveUser = 8,
                        IdRequest = 17,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 50,
                        IdApproveUser = 3,
                        IdRequest = 17,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 51,
                        IdApproveUser = 29,
                        IdRequest = 17,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 52,
                        IdApproveUser = 4,
                        IdRequest = 18,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 53,
                        IdApproveUser = 2,
                        IdRequest = 18,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 54,
                        IdApproveUser = 29,
                        IdRequest = 18,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 55,
                        IdApproveUser = 4,
                        IdRequest = 19,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 56,
                        IdApproveUser = 2,
                        IdRequest = 19,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 57,
                        IdApproveUser = 29,
                        IdRequest = 19,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 58,
                        IdApproveUser = 31,
                        IdRequest = 20,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 59,
                        IdApproveUser = 2,
                        IdRequest = 20,
                        IdComment = 1,
                        ApproveStatus = false
                    },
                    new UserRequest
                    {
                        Id = 60,
                        IdApproveUser = 29,
                        IdRequest = 20,
                        IdComment = 1,
                        ApproveStatus = false
                    });
            });

            OnModelCreatingPartial(modelBuilder);
        }
        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

        }
    }
}
