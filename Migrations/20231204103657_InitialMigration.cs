using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaryClub.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Honorary = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VerificationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordResetToken", "PasswordSalt", "ResetTokenExpires", "VerificationToken", "VerifiedAt" },
                values: new object[] { 1, "admin@admin.ba", new byte[] { 142, 235, 160, 37, 189, 132, 39, 31, 237, 167, 47, 61, 241, 126, 159, 144, 178, 228, 28, 11, 40, 26, 36, 28, 88, 0, 123, 215, 147, 15, 205, 167, 141, 164, 166, 26, 62, 74, 123, 50, 25, 234, 250, 225, 62, 181, 57, 211, 244, 6, 24, 157, 66, 235, 153, 12, 242, 125, 101, 107, 101, 203, 250, 70 }, null, new byte[] { 222, 245, 55, 190, 46, 43, 210, 170, 54, 50, 249, 94, 118, 46, 98, 179, 57, 211, 82, 94, 93, 225, 11, 163, 106, 170, 61, 90, 30, 207, 145, 46, 225, 2, 33, 206, 100, 248, 38, 28, 134, 215, 243, 171, 185, 155, 201, 227, 123, 147, 58, 171, 80, 81, 253, 254, 21, 220, 240, 21, 30, 211, 160, 179, 223, 75, 136, 148, 106, 163, 185, 24, 115, 45, 250, 159, 188, 237, 45, 154, 184, 255, 176, 163, 31, 136, 226, 55, 45, 210, 200, 1, 66, 237, 166, 193, 152, 202, 16, 234, 12, 68, 199, 197, 115, 62, 10, 175, 51, 95, 100, 42, 109, 65, 63, 98, 136, 251, 216, 70, 90, 162, 221, 90, 130, 245, 156, 70 }, null, "A447F6CC515CF4EDC0BFCE70AB1C3F920D5664263EB51CC88E12A24CB5E17EEC5F5EA4F48DE0E5EC2FB48A88A6DE439AD537B0FBA85A0F73E9F4F4D5DAF62714", new DateTime(2023, 12, 4, 11, 36, 56, 971, DateTimeKind.Local).AddTicks(1039) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
