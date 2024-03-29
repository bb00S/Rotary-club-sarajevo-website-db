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
    [Migration("20231221101641_InitialMigration")]
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

            modelBuilder.Entity("RotaryClub.Models.Tasks", b =>
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

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
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
                            PasswordHash = new byte[] { 126, 3, 170, 215, 216, 20, 49, 38, 104, 88, 246, 152, 30, 181, 106, 88, 247, 132, 213, 187, 164, 124, 21, 90, 180, 172, 126, 189, 70, 130, 174, 247, 164, 92, 124, 79, 143, 9, 234, 5, 25, 126, 141, 255, 72, 31, 243, 49, 89, 238, 99, 118, 6, 127, 170, 33, 165, 127, 208, 182, 94, 255, 67, 222 },
                            PasswordSalt = new byte[] { 14, 234, 134, 132, 195, 51, 46, 60, 138, 183, 121, 196, 133, 37, 39, 120, 159, 242, 231, 156, 20, 143, 123, 20, 185, 207, 156, 198, 81, 89, 185, 63, 85, 77, 138, 27, 192, 138, 112, 1, 190, 68, 230, 41, 147, 87, 125, 185, 194, 1, 66, 167, 36, 252, 92, 40, 151, 185, 110, 113, 60, 254, 19, 197, 151, 144, 168, 130, 106, 145, 205, 139, 114, 96, 31, 183, 208, 212, 39, 159, 9, 107, 246, 135, 57, 52, 209, 65, 55, 38, 62, 173, 151, 62, 11, 39, 16, 144, 248, 101, 93, 19, 109, 54, 111, 92, 182, 24, 146, 57, 219, 50, 238, 214, 0, 254, 123, 135, 220, 44, 112, 182, 24, 122, 173, 245, 225, 29 },
                            VerificationToken = "FD7227380A78FA074AF90E0FBBE13306CBA9B8AB34AE983FFBD5B4985428A35EAC7406D4FE6724BA619B22888DF1A63F9B5EA012CEBB9BB6D46F7ADCFB368D75",
                            VerifiedAt = new DateTime(2023, 12, 21, 11, 16, 41, 837, DateTimeKind.Local).AddTicks(5227)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
