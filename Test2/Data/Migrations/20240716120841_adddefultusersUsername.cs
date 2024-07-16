using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test2.Data.Migrations
{
    /// <inheritdoc />
    public partial class adddefultusersUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "363cfe19-710f-4035-8ffa-0ee5f7da077a",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "bebb588f-7957-4f25-a5fd-d3eb6fa94334", true, "TEST@TEST.COM", "AQAAAAIAAYagAAAAEGUoe2htKG+fgbMpmwdoN2fSBu3supeOqzJk3RdRW4VMQOJ24ftKQMjS/0Cbb88eFg==", "92dfd8e5-0c23-438b-aa5f-10047918eae3", "test@test.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b54618f-61e6-4a76-ba64-be6209bbff00",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "47122dd4-64c3-4eaa-93ed-b543254d2024", true, "MOHAMEEDA326@GMAIL.COM", "AQAAAAIAAYagAAAAEJ/fYt9m3kIrrtVjoKsKbKgbvrTywOQqe/l26NRNL4A0zUfoOlrKnMFNpWUCCnNOnA==", "e71bf544-4dcb-451a-8852-1619267fe6af", "mohameeda326@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "363cfe19-710f-4035-8ffa-0ee5f7da077a",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "a8911ee0-d84b-4e5a-86d7-19990a085154", false, null, "AQAAAAIAAYagAAAAELwcviNsmIVbjYCtTYV1qKBGhU4+BrxjhaZInG9JOPsleMLA8IwMv1fOthzbEd5TTw==", "167de90b-5c59-4f88-ba1b-71d0d2fdcc06", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b54618f-61e6-4a76-ba64-be6209bbff00",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "960c3fb1-4eb4-4ba5-b74d-e1f566412c08", false, null, "AQAAAAIAAYagAAAAEATfme/nDNgGTdYKpzcIBqNvlv6NnOHophERFVTIm6nRr0aerolbFF66+b6ygynK5g==", "b4e7a04b-b227-43d1-93ed-68b799d2ac08", null });
        }
    }
}
