using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test2.Data.Migrations
{
    /// <inheritdoc />
    public partial class addLeaveRequestTqble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeid = table.Column<int>(type: "int", nullable: false),
                    DateRequest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequrstComent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approve = table.Column<bool>(type: "bit", nullable: true),
                    CDancele = table.Column<bool>(type: "bit", nullable: false),
                    RequestEmployID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datecreat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datemodified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_leaveTypes_LeaveTypeid",
                        column: x => x.LeaveTypeid,
                        principalTable: "leaveTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "363cfe19-710f-4035-8ffa-0ee5f7da077a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0e32fef-018b-4a9e-b511-fbca52ba3eb4", "AQAAAAIAAYagAAAAEJaX/X/2PZ7oRTa38xfoDWbX/upqsuwpDaki7UBUxY4/3+ZSWw2lH4sdXqyUTcWPAQ==", "05b8aeb8-dc12-4866-967b-66740f3e9fc6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b54618f-61e6-4a76-ba64-be6209bbff00",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f1161e2-aea5-4721-baa8-0c48527b0c5f", "AQAAAAIAAYagAAAAEE5ZakbhEdIIMzTga6sCwlZUlrgHy6g8MXw111g6XOjZudAE/DkoAUHGnnsR8uy82A==", "6cd089ca-9d00-414a-b50d-b4525f5b85bc" });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeid",
                table: "LeaveRequests",
                column: "LeaveTypeid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

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
    }
}
