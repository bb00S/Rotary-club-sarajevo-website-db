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
                values: new object[] { 1, "admin@admin.ba", new byte[] { 45, 82, 39, 105, 3, 33, 39, 233, 35, 215, 245, 90, 40, 196, 65, 102, 127, 199, 74, 163, 114, 51, 120, 216, 5, 217, 43, 118, 96, 37, 189, 27, 27, 239, 30, 134, 58, 135, 65, 8, 57, 192, 74, 11, 44, 75, 115, 120, 186, 37, 126, 218, 186, 134, 27, 232, 178, 127, 247, 39, 221, 172, 208, 114 }, null, new byte[] { 205, 19, 227, 244, 120, 62, 83, 68, 196, 45, 23, 86, 206, 139, 143, 172, 140, 47, 55, 90, 222, 83, 146, 148, 98, 128, 113, 168, 26, 193, 98, 237, 118, 217, 191, 217, 174, 143, 51, 147, 189, 209, 104, 57, 117, 172, 80, 160, 78, 223, 129, 99, 233, 152, 180, 55, 68, 176, 153, 98, 248, 17, 86, 90, 44, 72, 64, 83, 140, 221, 34, 63, 20, 122, 59, 233, 142, 127, 164, 115, 223, 17, 239, 54, 201, 205, 38, 64, 226, 230, 174, 208, 139, 40, 219, 15, 37, 254, 21, 104, 17, 178, 145, 47, 62, 61, 57, 38, 60, 204, 213, 7, 214, 229, 223, 39, 236, 96, 162, 51, 139, 255, 63, 205, 185, 160, 118, 220 }, null, "B8B19CEA1A6EBDC9A7C6A95CA37DDEA19AC49F2049098A5DF5EFC87CE2BEA673F80ADC3C7D6E6DC3493770C1697095413DF3524BCA75DEEA3B2C8E65D70D0B78", new DateTime(2023, 11, 20, 9, 51, 33, 187, DateTimeKind.Local).AddTicks(3369) });
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
