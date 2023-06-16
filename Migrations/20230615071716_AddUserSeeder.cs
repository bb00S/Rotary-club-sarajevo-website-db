using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaryClub.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordResetToken", "PasswordSalt", "ResetTokenExpires", "VerificationToken", "VerifiedAt" },
                values: new object[] { 1, "admin@admin.ba", new byte[] { 138, 103, 108, 123, 164, 35, 169, 144, 234, 112, 21, 159, 175, 46, 207, 56, 237, 193, 163, 58, 178, 152, 203, 165, 163, 142, 181, 139, 240, 83, 204, 146, 49, 52, 104, 67, 146, 165, 117, 174, 75, 27, 242, 21, 74, 46, 89, 17, 146, 112, 28, 9, 71, 171, 119, 1, 90, 63, 183, 233, 10, 156, 213, 25 }, null, new byte[] { 93, 134, 219, 235, 93, 93, 128, 130, 43, 180, 56, 154, 122, 154, 202, 14, 194, 221, 216, 173, 253, 67, 188, 180, 154, 53, 151, 24, 211, 83, 206, 195, 58, 79, 114, 95, 212, 223, 163, 135, 183, 179, 163, 38, 63, 56, 205, 151, 136, 108, 176, 168, 66, 225, 164, 238, 219, 88, 224, 203, 227, 177, 242, 113, 63, 103, 35, 200, 134, 115, 185, 230, 0, 73, 146, 128, 45, 135, 194, 94, 139, 134, 40, 216, 203, 106, 67, 248, 113, 18, 249, 193, 104, 60, 19, 176, 126, 130, 56, 8, 26, 155, 234, 150, 119, 94, 3, 197, 169, 29, 152, 215, 91, 227, 122, 66, 9, 136, 82, 156, 118, 240, 236, 170, 195, 185, 105, 242 }, null, "7D1F9F750B66DAA6EF3CE58AF29C173A2232003508420A45C4C95279BEB72F79A46052C3DA5719CFEF9F7FA638441DBF44690DA90F26E9F3AF9E48AC855728B0", new DateTime(2023, 6, 15, 9, 17, 16, 216, DateTimeKind.Local).AddTicks(7778) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
