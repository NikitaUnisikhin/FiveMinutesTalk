using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiveMinutesTalk.Migrations
{
    /// <inheritdoc />
    public partial class _newInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
