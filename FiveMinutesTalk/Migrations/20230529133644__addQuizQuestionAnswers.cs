using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiveMinutesTalk.Migrations
{
    /// <inheritdoc />
    public partial class _addQuizQuestionAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "9e79f088-551f-4b23-b19a-b1536f94b457", "AQAAAAIAAYagAAAAEN5ZBebkCZOwcoyDlUe8hCxkC0LEcRgi9uG2e/MoKN03DvZjXyd9bonrUORVlgTAXA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BCF8F1A1-A9BA-480F-A16C-88DBDCFAA9AC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3f563c82-7698-4bcb-a0df-938c90372511", "AQAAAAIAAYagAAAAECzPFP8BD9Bzh4Qj6RSImEfVfH4yZD2k0CNd+DPieUFQVroOaUwTsU8vn4LDIByOlQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizAnswers");

            migrationBuilder.DropTable(
                name: "QuizQuestionAnswers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3835c7a6-1f1e-4884-b16f-598faf1b1177", "AQAAAAIAAYagAAAAEH4jIZzEHv1Qg/ZbWxmNb5KNH8AcOFJ7pDYdsMktlEgSvc/oNU6K27tBefR6akFJmQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BCF8F1A1-A9BA-480F-A16C-88DBDCFAA9AC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "72a39814-dbc9-4d2b-95f2-4cf9f585c35e", "AQAAAAIAAYagAAAAEKpgVO7KeDoj+3lp+ncbx92kqeNAfmtFAN5N/Dev1mLB6oF17r3EeTxej4kB/8v+XQ==" });
        }
    }
}
