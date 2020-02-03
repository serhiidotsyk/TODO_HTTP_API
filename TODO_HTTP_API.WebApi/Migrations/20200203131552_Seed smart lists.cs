using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TODO_HTTP_API.WebApi.Migrations
{
    public partial class Seedsmartlists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 2, 3, 15, 15, 50, 591, DateTimeKind.Local).AddTicks(9337));

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "Id", "Name", "ReturnCompleted", "ToDoListType", "UserId" },
                values: new object[,]
                {
                    { 2, "Planned Tasks", false, 0, 1 },
                    { 3, "Important Tasks", false, 0, 1 },
                    { 4, "Today's Tasks", false, 0, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 2, 3, 13, 51, 23, 151, DateTimeKind.Local).AddTicks(2332));
        }
    }
}
