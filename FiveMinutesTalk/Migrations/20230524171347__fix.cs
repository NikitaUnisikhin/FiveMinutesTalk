using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiveMinutesTalk.Migrations
{
    /// <inheritdoc />
    public partial class _fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "QuizId",
                table: "QuestionAnswers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "QuestionAnswers");

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
    }
}
