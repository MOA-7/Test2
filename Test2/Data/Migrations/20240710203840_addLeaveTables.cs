using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test2.Data.Migrations
{
    /// <inheritdoc />
    public partial class addLeaveTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "leaveTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    named = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefultDays = table.Column<int>(type: "int", nullable: false),
                    datecreat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datemodified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaveTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveAllocations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfDAYS = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeid = table.Column<int>(type: "int", nullable: false),
                    Employid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datecreat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datemodified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveAllocations", x => x.id);
                    table.ForeignKey(
                        name: "FK_LeaveAllocations_leaveTypes_LeaveTypeid",
                        column: x => x.LeaveTypeid,
                        principalTable: "leaveTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveAllocations_LeaveTypeid",
                table: "LeaveAllocations",
                column: "LeaveTypeid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveAllocations");

            migrationBuilder.DropTable(
                name: "leaveTypes");
        }
    }
}
