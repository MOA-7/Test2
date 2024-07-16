using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test2.Data.Migrations
{
    /// <inheritdoc />
    public partial class adddefultusersandRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33e6a5bb-209a-49a4-a39d-783ffed4efb0", null, "Admin", "ADMIN" },
                    { "e2c4e32b-9c45-41bb-8f7a-74ca17e00361", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "datejoind", "dateodbirth", "lastname", "name", "taxid" },
                values: new object[,]
                {
                    { "363cfe19-710f-4035-8ffa-0ee5f7da077a", 0, "a8911ee0-d84b-4e5a-86d7-19990a085154", "test@test.com", false, false, null, "TEST@TEST.COM", null, "AQAAAAIAAYagAAAAELwcviNsmIVbjYCtTYV1qKBGhU4+BrxjhaZInG9JOPsleMLA8IwMv1fOthzbEd5TTw==", null, false, "167de90b-5c59-4f88-ba1b-71d0d2fdcc06", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "uest", "test", null },
                    { "8b54618f-61e6-4a76-ba64-be6209bbff00", 0, "960c3fb1-4eb4-4ba5-b74d-e1f566412c08", "mohameeda326@gmail.com", false, false, null, "MOHAMEEDA326@GMAIL.COM", null, "AQAAAAIAAYagAAAAEATfme/nDNgGTdYKpzcIBqNvlv6NnOHophERFVTIm6nRr0aerolbFF66+b6ygynK5g==", null, false, "b4e7a04b-b227-43d1-93ed-68b799d2ac08", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali raheem", "Mohammed", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e2c4e32b-9c45-41bb-8f7a-74ca17e00361", "363cfe19-710f-4035-8ffa-0ee5f7da077a" },
                    { "33e6a5bb-209a-49a4-a39d-783ffed4efb0", "8b54618f-61e6-4a76-ba64-be6209bbff00" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e2c4e32b-9c45-41bb-8f7a-74ca17e00361", "363cfe19-710f-4035-8ffa-0ee5f7da077a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "33e6a5bb-209a-49a4-a39d-783ffed4efb0", "8b54618f-61e6-4a76-ba64-be6209bbff00" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33e6a5bb-209a-49a4-a39d-783ffed4efb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2c4e32b-9c45-41bb-8f7a-74ca17e00361");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "363cfe19-710f-4035-8ffa-0ee5f7da077a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b54618f-61e6-4a76-ba64-be6209bbff00");
        }
    }
}
