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
                .HasMaxLength(30)
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
                        Email = "dephead@gamil.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "dephead",
                        Birthdate = new DateTime(2000, 8, 11),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 2
                    },
                    new User
                    {
                        Id = 3,
                        FirstName = "Andrii",
                        LastName = "Salii",
                        Email = "employee@gmail.com",
                        Password = RC5Helper.HashMes("_Aa123456"),
                        RefreshToken = "employee",
                        Birthdate = new DateTime(2000, 8, 11),
                        RegisterDate = new DateTime(2020, 6, 1),
                        NotificationPermission = true,
                        IdUserRole = 3
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

            OnModelCreatingPartial(modelBuilder);
        }
        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

        }
    }
}
