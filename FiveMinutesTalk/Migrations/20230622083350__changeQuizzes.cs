using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiveMinutesTalk.Migrations
{
    /// <inheritdoc />
    public partial class _changeQuizzes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Quizzes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "35c9ffef-eb0d-43e0-94f6-a9dd7e4deadf", "AQAAAAIAAYagAAAAEBHS+yre1nzZEEQv+Myz1lEP3kIFrBQRgXCVR1QisOc1NI1qr6K7NER3PJsxeCiAeQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BCF8F1A1-A9BA-480F-A16C-88DBDCFAA9AC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "00f0b031-805c-4134-a5a1-37fbe943eb40", "AQAAAAIAAYagAAAAENuG1qlxAmCG6eqLJJJPO05AzSf+DgWiHIkM4NvYTiC0wk9bOAoeKmtNo56Ag0eE1w==" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("8b95163b-8485-40d6-bafd-51785ad6e9d2"),
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("4043b854-c29f-4dca-900c-0387de52d250"),
                column: "OwnerId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Quizzes");

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

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("8b95163b-8485-40d6-bafd-51785ad6e9d2"),
                column: "Type",
                value: 1);
        }
    }
}
