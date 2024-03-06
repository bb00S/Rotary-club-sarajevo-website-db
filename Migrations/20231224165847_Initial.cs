using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaryClub.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "VerificationToken", "VerifiedAt" },
                values: new object[] { new byte[] { 154, 152, 149, 225, 223, 90, 186, 104, 178, 146, 38, 123, 19, 134, 75, 187, 223, 132, 255, 79, 85, 157, 192, 158, 79, 83, 150, 29, 246, 104, 115, 167, 207, 171, 123, 243, 152, 106, 118, 37, 67, 184, 251, 186, 147, 113, 60, 1, 221, 29, 183, 157, 185, 53, 156, 46, 215, 149, 133, 209, 167, 11, 190, 144 }, new byte[] { 141, 194, 53, 37, 209, 161, 247, 137, 132, 81, 57, 220, 0, 96, 216, 100, 100, 70, 241, 19, 114, 126, 147, 124, 144, 113, 132, 136, 62, 77, 170, 7, 88, 77, 236, 165, 61, 247, 130, 153, 187, 106, 252, 197, 18, 18, 223, 252, 167, 166, 98, 66, 117, 143, 117, 206, 67, 164, 79, 253, 27, 14, 234, 83, 78, 40, 203, 183, 151, 151, 206, 153, 174, 226, 86, 17, 150, 87, 221, 123, 237, 26, 119, 86, 159, 33, 80, 125, 173, 174, 51, 172, 208, 77, 90, 136, 82, 142, 136, 170, 190, 126, 127, 123, 245, 127, 63, 39, 219, 94, 38, 210, 148, 186, 120, 129, 102, 86, 178, 18, 111, 232, 33, 63, 83, 213, 45, 57 }, "287A7C4040D92136082081F35CEEE4EF1CB7D1EAF352FD0D6ACC30AE40D6D2BEAB07C6BD2720B3F570E3F5D2E6F45ABEF7865D2F1185FF0F2471D1465387E1DB", new DateTime(2023, 12, 24, 17, 58, 46, 785, DateTimeKind.Local).AddTicks(8578) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "VerificationToken", "VerifiedAt" },
                values: new object[] { new byte[] { 126, 3, 170, 215, 216, 20, 49, 38, 104, 88, 246, 152, 30, 181, 106, 88, 247, 132, 213, 187, 164, 124, 21, 90, 180, 172, 126, 189, 70, 130, 174, 247, 164, 92, 124, 79, 143, 9, 234, 5, 25, 126, 141, 255, 72, 31, 243, 49, 89, 238, 99, 118, 6, 127, 170, 33, 165, 127, 208, 182, 94, 255, 67, 222 }, new byte[] { 14, 234, 134, 132, 195, 51, 46, 60, 138, 183, 121, 196, 133, 37, 39, 120, 159, 242, 231, 156, 20, 143, 123, 20, 185, 207, 156, 198, 81, 89, 185, 63, 85, 77, 138, 27, 192, 138, 112, 1, 190, 68, 230, 41, 147, 87, 125, 185, 194, 1, 66, 167, 36, 252, 92, 40, 151, 185, 110, 113, 60, 254, 19, 197, 151, 144, 168, 130, 106, 145, 205, 139, 114, 96, 31, 183, 208, 212, 39, 159, 9, 107, 246, 135, 57, 52, 209, 65, 55, 38, 62, 173, 151, 62, 11, 39, 16, 144, 248, 101, 93, 19, 109, 54, 111, 92, 182, 24, 146, 57, 219, 50, 238, 214, 0, 254, 123, 135, 220, 44, 112, 182, 24, 122, 173, 245, 225, 29 }, "FD7227380A78FA074AF90E0FBBE13306CBA9B8AB34AE983FFBD5B4985428A35EAC7406D4FE6724BA619B22888DF1A63F9B5EA012CEBB9BB6D46F7ADCFB368D75", new DateTime(2023, 12, 21, 11, 16, 41, 837, DateTimeKind.Local).AddTicks(5227) });
        }
    }
}
