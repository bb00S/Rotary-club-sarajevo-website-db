﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RotaryClub.Data;

#nullable disable

namespace RotaryClub.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231204103657_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RotaryClub.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Honorary")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("RotaryClub.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("RotaryClub.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("VerifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@admin.ba",
                            PasswordHash = new byte[] { 142, 235, 160, 37, 189, 132, 39, 31, 237, 167, 47, 61, 241, 126, 159, 144, 178, 228, 28, 11, 40, 26, 36, 28, 88, 0, 123, 215, 147, 15, 205, 167, 141, 164, 166, 26, 62, 74, 123, 50, 25, 234, 250, 225, 62, 181, 57, 211, 244, 6, 24, 157, 66, 235, 153, 12, 242, 125, 101, 107, 101, 203, 250, 70 },
                            PasswordSalt = new byte[] { 222, 245, 55, 190, 46, 43, 210, 170, 54, 50, 249, 94, 118, 46, 98, 179, 57, 211, 82, 94, 93, 225, 11, 163, 106, 170, 61, 90, 30, 207, 145, 46, 225, 2, 33, 206, 100, 248, 38, 28, 134, 215, 243, 171, 185, 155, 201, 227, 123, 147, 58, 171, 80, 81, 253, 254, 21, 220, 240, 21, 30, 211, 160, 179, 223, 75, 136, 148, 106, 163, 185, 24, 115, 45, 250, 159, 188, 237, 45, 154, 184, 255, 176, 163, 31, 136, 226, 55, 45, 210, 200, 1, 66, 237, 166, 193, 152, 202, 16, 234, 12, 68, 199, 197, 115, 62, 10, 175, 51, 95, 100, 42, 109, 65, 63, 98, 136, 251, 216, 70, 90, 162, 221, 90, 130, 245, 156, 70 },
                            VerificationToken = "A447F6CC515CF4EDC0BFCE70AB1C3F920D5664263EB51CC88E12A24CB5E17EEC5F5EA4F48DE0E5EC2FB48A88A6DE439AD537B0FBA85A0F73E9F4F4D5DAF62714",
                            VerifiedAt = new DateTime(2023, 12, 4, 11, 36, 56, 971, DateTimeKind.Local).AddTicks(1039)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}