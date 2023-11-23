using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaryClub.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
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
                values: new object[] { 1, "admin@admin.ba", new byte[] { 26, 120, 152, 215, 127, 70, 145, 100, 137, 226, 230, 49, 164, 192, 117, 152, 110, 156, 130, 209, 27, 152, 33, 65, 16, 182, 91, 41, 6, 30, 97, 153, 180, 240, 51, 178, 62, 17, 248, 151, 54, 172, 74, 164, 28, 54, 153, 83, 147, 97, 169, 60, 170, 122, 195, 63, 83, 57, 209, 228, 138, 254, 229, 127 }, null, new byte[] { 231, 144, 223, 210, 169, 72, 229, 202, 120, 72, 159, 207, 118, 197, 11, 14, 59, 186, 94, 67, 40, 220, 41, 46, 95, 1, 249, 121, 138, 239, 152, 23, 115, 230, 8, 41, 121, 140, 15, 7, 5, 130, 156, 19, 162, 244, 93, 112, 208, 90, 104, 248, 80, 12, 64, 250, 147, 153, 34, 126, 245, 148, 221, 226, 9, 141, 240, 199, 130, 136, 13, 116, 158, 251, 25, 176, 107, 77, 29, 29, 41, 245, 140, 105, 74, 211, 194, 241, 250, 24, 110, 51, 101, 230, 139, 66, 59, 126, 88, 171, 207, 153, 55, 179, 141, 68, 35, 206, 145, 77, 18, 4, 87, 27, 83, 75, 60, 92, 33, 16, 168, 183, 49, 10, 81, 215, 26, 7 }, null, "306FAA2768C791830B866C48F10DAD95EF9DB52602B7867199B9ADD0AA717114804AA16AECB5DCB9FDF9E15207B47DCE8CA26761FDEEAACC1217E49DB2E33F86", new DateTime(2023, 11, 20, 11, 15, 22, 393, DateTimeKind.Local).AddTicks(5469) });
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
