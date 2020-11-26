﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestCookieWeb.DAL;

namespace TestCookieWeb.DAL.Migrations
{
    [DbContext(typeof(TestCookiesDbContext))]
    partial class TestCookiesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TestCookieWeb.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_User")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("IdUserRole")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("NotificationPermission")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("XPKUser");

                    b.HasIndex("IdUserRole");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthdate = new DateTime(2000, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@gmail.com",
                            FirstName = "Volodymyr",
                            IdUserRole = 1,
                            LastName = "Kulchytskyi",
                            NotificationPermission = true,
                            Password = "B9-0F-FB-AD-D6-FA-0E-AC-C1-47-1E-57-5F-E9-C7-B1",
                            RefreshToken = "admin",
                            RegisterDate = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Birthdate = new DateTime(2000, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "dephead@gamil.com",
                            FirstName = "Liubomyr",
                            IdUserRole = 2,
                            LastName = "Skalskyi",
                            NotificationPermission = true,
                            Password = "B9-0F-FB-AD-D6-FA-0E-AC-C1-47-1E-57-5F-E9-C7-B1",
                            RefreshToken = "dephead",
                            RegisterDate = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Birthdate = new DateTime(2000, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "employee@gmail.com",
                            FirstName = "Andrii",
                            IdUserRole = 3,
                            LastName = "Salii",
                            NotificationPermission = true,
                            Password = "B9-0F-FB-AD-D6-FA-0E-AC-C1-47-1E-57-5F-E9-C7-B1",
                            RefreshToken = "employee",
                            RegisterDate = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("TestCookieWeb.Core.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_UserRole")
                        .UseIdentityColumn();

                    b.Property<bool>("ChangeUserRole")
                        .HasColumnType("bit");

                    b.Property<bool>("ManageUserList")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("WorkWithHierarchy")
                        .HasColumnType("bit");

                    b.HasKey("Id")
                        .HasName("XPKUserRole");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChangeUserRole = true,
                            ManageUserList = true,
                            Title = "admin",
                            WorkWithHierarchy = true
                        },
                        new
                        {
                            Id = 2,
                            ChangeUserRole = false,
                            ManageUserList = false,
                            Title = "dephead",
                            WorkWithHierarchy = true
                        },
                        new
                        {
                            Id = 3,
                            ChangeUserRole = false,
                            ManageUserList = false,
                            Title = "employee",
                            WorkWithHierarchy = false
                        });
                });

            modelBuilder.Entity("TestCookieWeb.Core.Models.User", b =>
                {
                    b.HasOne("TestCookieWeb.Core.Models.UserRole", "IdUserRoleNavigation")
                        .WithMany("User")
                        .HasForeignKey("IdUserRole")
                        .HasConstraintName("R_21");

                    b.Navigation("IdUserRoleNavigation");
                });

            modelBuilder.Entity("TestCookieWeb.Core.Models.UserRole", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}