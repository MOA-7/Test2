using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test2.Data.Migrations
{
    /// <inheritdoc />
    public partial class periodtoapplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "363cfe19-710f-4035-8ffa-0ee5f7da077a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97dee71a-ac75-446b-a563-6fe9cd81e006", "AQAAAAIAAYagAAAAEICbGp9corLvYOg8UBdC0mnf3gxBvGQmO4pdQKlP2AE7XB9RcrfN3HROqyu9GSfZpA==", "000c7529-b04d-4d86-9d23-81afac4675a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b54618f-61e6-4a76-ba64-be6209bbff00",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0fe3ae3-a931-408a-a50a-b32103c2e319", "AQAAAAIAAYagAAAAEB0UKdZcg0S4OxN8qQ9FhjdTSf98xe92s5QKo9KM4Y4VZt6QuSpXK5dw/sZF8/fQew==", "656e4d5d-db95-416b-a132-ecc487f818ed" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "period",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "363cfe19-710f-4035-8ffa-0ee5f7da077a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bebb588f-7957-4f25-a5fd-d3eb6fa94334", "AQAAAAIAAYagAAAAEGUoe2htKG+fgbMpmwdoN2fSBu3supeOqzJk3RdRW4VMQOJ24ftKQMjS/0Cbb88eFg==", "92dfd8e5-0c23-438b-aa5f-10047918eae3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b54618f-61e6-4a76-ba64-be6209bbff00",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47122dd4-64c3-4eaa-93ed-b543254d2024", "AQAAAAIAAYagAAAAEJ/fYt9m3kIrrtVjoKsKbKgbvrTywOQqe/l26NRNL4A0zUfoOlrKnMFNpWUCCnNOnA==", "e71bf544-4dcb-451a-8852-1619267fe6af" });
        }
    }
}
