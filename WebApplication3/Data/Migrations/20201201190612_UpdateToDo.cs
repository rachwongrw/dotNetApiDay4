using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Data.Migrations
{
    public partial class UpdateToDo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ToDos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "ToDos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Priority" },
                values: new object[] { new DateTime(2020, 12, 1, 11, 6, 12, 68, DateTimeKind.Local).AddTicks(2856), 1 });

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Priority" },
                values: new object[] { new DateTime(2020, 12, 1, 11, 6, 12, 74, DateTimeKind.Local).AddTicks(4993), 1 });

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Priority" },
                values: new object[] { new DateTime(2020, 12, 1, 11, 6, 12, 74, DateTimeKind.Local).AddTicks(5089), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "ToDos");
        }
    }
}
