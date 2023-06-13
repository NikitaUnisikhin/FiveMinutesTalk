using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiveMinutesTalk.Migrations
{
    /// <inheritdoc />
    public partial class _test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuizId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionType = table.Column<int>(type: "integer", nullable: false),
                    Answers = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuizAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuizId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizAnswers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuizAnswerId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionAnswerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestionAnswers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ce2621cd-1547-411d-bed5-afbcd3348609", "AQAAAAIAAYagAAAAEMP6GWlFjQszj0VwegsIs7r1Vg4MuJjrQGfJTqS4sa9sV+Gj65/Y97FcnwtWUvSlSQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BCF8F1A1-A9BA-480F-A16C-88DBDCFAA9AC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "48b26dee-3802-45e1-ba86-68178b6aba65", "AQAAAAIAAYagAAAAEER/z4zE1T9k3xLgWew2bHjTbE82gQzAk1q0M0nwPCm/CmmmtatlY6M6PxJcuBCc9A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionAnswers");

            migrationBuilder.DropTable(
                name: "QuizAnswers");

            migrationBuilder.DropTable(
                name: "QuizQuestionAnswers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f4a7a18a-1861-45e7-bfc7-994bf944348a", "AQAAAAIAAYagAAAAEIxxFzW05iHqWVtdT115M3J4gFL90iQGMxH+2esgNMnrIkst1R+KQmrqQcTwsD/qag==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BCF8F1A1-A9BA-480F-A16C-88DBDCFAA9AC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b8f27bbd-a241-42cf-8230-7fefcb6e6932", "AQAAAAIAAYagAAAAEO/5WEWF/bRWArqLR3tYrsHDtUxFDaDlfDqKo8PUTcnoHXjzX0hPLNxl4B10vtRVRw==" });
        }
    }
}
