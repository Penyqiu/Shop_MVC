using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUserandRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9fc6668e-0dbe-41f8-b30c-9faa3825bfcb", "951f02d6-23fa-4ad7-8fd1-7acd211a8c40", "Administrator", "ADMINISTRATOR" },
                    { "ae42a2b3-5943-4f71-88b2-0f41575f266c", "b5859938-71cb-4870-98b5-f0df4ecb52d0", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "008614fd-3840-4c98-b99e-03d69e677483", 0, "9da6c1f1-30e0-49e7-b784-64665635553e", "user@user.com", false, "System", "User", false, null, "USER@USER.COM", "USER@USER.COM", "AQAAAAEAACcQAAAAEIJKB9SkcKwnDbubXRZeDJH3g9bhzDf8va676JWQKpnDsMhZ7/qei6lAA1mKYKWkXA==", null, false, "3769afbb-641f-4fe2-9dcb-a43180130ba2", false, "user@user.com" },
                    { "ae42a2b3-5943-4f71-88b2-0f41575f266c", 0, "df8aa856-81ef-4d3a-9a69-9d524381d999", "admin@admin.com", false, "System", "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAECD2mTq3XIKorYCPaWcKIKLwvQL5qOf71akd00/hczkVwMNfK77FbgeO19upJysDwg==", null, false, "02c41d71-a507-456a-b634-9d1c9b7db193", false, "admin@admin.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ae42a2b3-5943-4f71-88b2-0f41575f266c", "008614fd-3840-4c98-b99e-03d69e677483" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9fc6668e-0dbe-41f8-b30c-9faa3825bfcb", "ae42a2b3-5943-4f71-88b2-0f41575f266c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ae42a2b3-5943-4f71-88b2-0f41575f266c", "008614fd-3840-4c98-b99e-03d69e677483" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9fc6668e-0dbe-41f8-b30c-9faa3825bfcb", "ae42a2b3-5943-4f71-88b2-0f41575f266c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fc6668e-0dbe-41f8-b30c-9faa3825bfcb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae42a2b3-5943-4f71-88b2-0f41575f266c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "008614fd-3840-4c98-b99e-03d69e677483");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae42a2b3-5943-4f71-88b2-0f41575f266c");
        }
    }
}
