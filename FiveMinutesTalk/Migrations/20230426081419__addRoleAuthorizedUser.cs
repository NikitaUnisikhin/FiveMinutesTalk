using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiveMinutesTalk.Migrations
{
    /// <inheritdoc />
    public partial class _addRoleAuthorizedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "authorizedUser", "AUTHORIZEDUSER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ed2be62f-471e-4f6b-9a34-529110ea5613", "AQAAAAIAAYagAAAAEAK+D5lOLBJdsKLfP2TOIEluBK2o3MmyEVejoXGe8bNUsw9aaentUY890IzjZg0EKw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "10ac3ae7-5456-41c1-8ca5-09ecbee2f3e9", "AQAAAAIAAYagAAAAEESqFDwR3PmUEXU3Q/bVUGlFX95+JBSVnVxSN4lLhUw0uyBmFLayJ2FngeI3aJpdJA==" });
        }
    }
}
