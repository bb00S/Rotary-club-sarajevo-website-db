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
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
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
                values: new object[] { 1, "admin@admin.ba", new byte[] { 126, 3, 170, 215, 216, 20, 49, 38, 104, 88, 246, 152, 30, 181, 106, 88, 247, 132, 213, 187, 164, 124, 21, 90, 180, 172, 126, 189, 70, 130, 174, 247, 164, 92, 124, 79, 143, 9, 234, 5, 25, 126, 141, 255, 72, 31, 243, 49, 89, 238, 99, 118, 6, 127, 170, 33, 165, 127, 208, 182, 94, 255, 67, 222 }, null, new byte[] { 14, 234, 134, 132, 195, 51, 46, 60, 138, 183, 121, 196, 133, 37, 39, 120, 159, 242, 231, 156, 20, 143, 123, 20, 185, 207, 156, 198, 81, 89, 185, 63, 85, 77, 138, 27, 192, 138, 112, 1, 190, 68, 230, 41, 147, 87, 125, 185, 194, 1, 66, 167, 36, 252, 92, 40, 151, 185, 110, 113, 60, 254, 19, 197, 151, 144, 168, 130, 106, 145, 205, 139, 114, 96, 31, 183, 208, 212, 39, 159, 9, 107, 246, 135, 57, 52, 209, 65, 55, 38, 62, 173, 151, 62, 11, 39, 16, 144, 248, 101, 93, 19, 109, 54, 111, 92, 182, 24, 146, 57, 219, 50, 238, 214, 0, 254, 123, 135, 220, 44, 112, 182, 24, 122, 173, 245, 225, 29 }, null, "FD7227380A78FA074AF90E0FBBE13306CBA9B8AB34AE983FFBD5B4985428A35EAC7406D4FE6724BA619B22888DF1A63F9B5EA012CEBB9BB6D46F7ADCFB368D75", new DateTime(2023, 12, 21, 11, 16, 41, 837, DateTimeKind.Local).AddTicks(5227) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
