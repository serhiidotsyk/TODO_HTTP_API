using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TODO_HTTP_API.WebApi.Migrations
{
    public partial class Seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "DateCreated", "Description", "DueDate", "Importance", "IsCompleted", "IsDeleted", "Title" },
                values: new object[] { 1, new DateTime(2020, 2, 3, 13, 51, 23, 151, DateTimeKind.Local).AddTicks(2332), "Do it anyway", null, 2, false, false, "Earn 1 million dollars" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "John" });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "Id", "Name", "ReturnCompleted", "ToDoListType", "UserId" },
                values: new object[] { 1, "All Tasks", false, 0, 1 });

            migrationBuilder.InsertData(
                table: "ListTasks",
                columns: new[] { "ListId", "TaskId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ListTasks",
                keyColumns: new[] { "ListId", "TaskId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
