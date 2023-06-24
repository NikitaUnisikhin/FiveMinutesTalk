using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiveMinutesTalk.Migrations
{
    /// <inheritdoc />
    public partial class _addQuestionAnswersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionType = table.Column<int>(type: "integer", nullable: false),
                    Answers = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f829c7e8-b190-4058-ae95-591734438084", "AQAAAAIAAYagAAAAEE3kRvPQRrl5NHVRtMmqdFqcoFHoDWnwAXI9U6KNsLXvi4TLeWVdIVqjQUE2/RgpXw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BCF8F1A1-A9BA-480F-A16C-88DBDCFAA9AC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a6a92316-c0de-4fb8-85b3-4404076bca41", "AQAAAAIAAYagAAAAELmqTsoErcrRjA2HWRgJysg/uBNRhYOERuSsjTJqHRUHR1HrlXpw59WBDK7ExQZbwg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionAnswers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5c3db82c-1261-48c8-977a-cf889c35b337", "AQAAAAIAAYagAAAAEF8U0QG6gbObU9wQlQ4b5y46fue4mgQpa3A9ncBjkRN0Gg5fBymS0n+Ky2N4Q/RZCg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BCF8F1A1-A9BA-480F-A16C-88DBDCFAA9AC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "400c1326-4033-4ce1-9666-88f1d9911ba8", "AQAAAAIAAYagAAAAEHhnATdDK7Bc34dqklE3X1uggHzwB+pApY4gf4f34Yg+iuJx86FYmNDkmFBN/Hl5Yw==" });
        }
    }
}
