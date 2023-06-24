using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiveMinutesTalk.Migrations
{
    /// <inheritdoc />
    public partial class _changeQuizzesAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Quizzes",
                newName: "Start");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Quizzes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Quizzes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9cdfa9c8-03a9-442f-826a-0feb15691012", "AQAAAAIAAYagAAAAEN7+4FvKfMtlhME+0WGVnJ71sPcuw3PQ2bgOq7MbnFhCgkjK0XzOs0hGIao67Xf6Og==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BCF8F1A1-A9BA-480F-A16C-88DBDCFAA9AC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "600558e3-ac70-4867-a810-9572e099a04c", "AQAAAAIAAYagAAAAEA3MzXpAfROKlwuaArj9S6fGoh4ZNpKMGdEH1lyMflGxHR4gMAxUxEOHW/f5eoc4Hg==" });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("4043b854-c29f-4dca-900c-0387de52d250"),
                columns: new[] { "CreationDate", "End" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Quizzes");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Quizzes",
                newName: "EndDate");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "efc8c9ff-2d03-49bf-9c92-5b91bf815e88", "AQAAAAIAAYagAAAAEBU535YriH0R8js03CcZcdZGt9f6w24ccnulHpb/jyUEqSHCxY3C7Esf9Gs1rzQrwQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BCF8F1A1-A9BA-480F-A16C-88DBDCFAA9AC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7ffbd348-097e-4a20-afe6-9cc431eb8abf", "AQAAAAIAAYagAAAAEKhhulBleKUCHkkaYCDS8Wn4Muj2D+kHob00TUc63XpDHtQBGPk2CFgDweEjQsBKgQ==" });
        }
    }
}
