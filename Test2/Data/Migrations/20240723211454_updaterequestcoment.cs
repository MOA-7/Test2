using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test2.Data.Migrations
{
    /// <inheritdoc />
    public partial class updaterequestcoment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequrstComent",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "363cfe19-710f-4035-8ffa-0ee5f7da077a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8137ae4-4f57-41e4-8358-27fc59530dd6", "AQAAAAIAAYagAAAAEHZ9p70yEwDYvWnQBIMwKcuDq/7f+G+5DTJnoEfu0DQPNpDJ4iByJu8TDeVmFlMHFQ==", "93c98076-9eb4-4ccb-9434-84787a1a345c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b54618f-61e6-4a76-ba64-be6209bbff00",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d901bf3-8809-4d7e-a050-178bad232d74", "AQAAAAIAAYagAAAAEPkYK8a2t+CktzvmCdx2FzAtjJmSisFEpwZVk7eL6AFzGh5px3r/VMHnXrZxLEUlNQ==", "6f7a178d-ef41-4cea-bfcd-b402ec281e10" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequrstComent",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
