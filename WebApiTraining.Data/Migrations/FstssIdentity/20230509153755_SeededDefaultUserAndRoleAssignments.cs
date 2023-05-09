using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiTraining.Data.Migrations.FstssIdentity
{
    /// <inheritdoc />
    public partial class SeededDefaultUserAndRoleAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "60036f2e-61a7-4b91-927d-b433e1143d0c", null, "Admin", "ADMIN" },
                    { "7fe60b48-3fcf-4498-a031-ac2e681a424b", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4d832879-2aa4-43dd-a85e-897334591cc1", 0, "b668a21f-9bc3-470c-b6fe-4e0bca5da9b7", "kevin.d.morgan@gdit.com", true, "Kevin", "Morgan", false, null, "KEVIN.D.MORGAN@GDIT.COM", "KEVIN.D.MORGAN@GDIT.COM", "AQAAAAIAAYagAAAAEDpqzP1zN9smYKxEMOLYG0ZoFRQIeb6v5Xzr4t7XLmBroNrDOQHrqam1OLWyp+FihQ==", null, false, "6ad1feff-bfa4-4c56-ab43-2cf0284b0a50", false, "kevin.d.morgan@gdit.com" },
                    { "6b25a9d8-cfff-48dd-9e66-5d4ad6c5c569", 0, "b5059152-2ddd-4aa9-882d-153da20fdd3d", "kmorgan26@gmail.com", true, "Kevin", "Morgan", false, null, "KMORGAN26@GMAIL.COM", "KMORGAN26@GMAIL.COM", "AQAAAAIAAYagAAAAEOsrAGy4RHC1CBIuUbogzH4Zgx3CGZDBQn9/7ofOzmYbcR2XFy6zSahdOJNqkz4DvQ==", null, false, "539fb648-5b5f-4913-a0cc-5cb1bd815d35", false, "KMORGAN26@GMAIL.COM" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "60036f2e-61a7-4b91-927d-b433e1143d0c", "4d832879-2aa4-43dd-a85e-897334591cc1" },
                    { "7fe60b48-3fcf-4498-a031-ac2e681a424b", "6b25a9d8-cfff-48dd-9e66-5d4ad6c5c569" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "60036f2e-61a7-4b91-927d-b433e1143d0c", "4d832879-2aa4-43dd-a85e-897334591cc1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7fe60b48-3fcf-4498-a031-ac2e681a424b", "6b25a9d8-cfff-48dd-9e66-5d4ad6c5c569" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60036f2e-61a7-4b91-927d-b433e1143d0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fe60b48-3fcf-4498-a031-ac2e681a424b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d832879-2aa4-43dd-a85e-897334591cc1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b25a9d8-cfff-48dd-9e66-5d4ad6c5c569");
        }
    }
}
