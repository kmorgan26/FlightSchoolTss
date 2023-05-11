using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlightSchoolTss.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededPlatformInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Maintainers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Flight Safety" },
                    { 2, "CAE" },
                    { 3, "AVT" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "IsActive", "MaintainerId", "Name" },
                values: new object[,]
                {
                    { 1, false, 1, "AH-64E" },
                    { 2, true, 2, "CH-47F" },
                    { 3, true, 1, "TH-1H" },
                    { 4, true, 2, "UH-60L" },
                    { 5, true, 2, "UH-60M" },
                    { 6, true, 1, "UH-72A" },
                    { 7, true, 1, "UH-72CPT" }
                });

            migrationBuilder.InsertData(
                table: "Simulators",
                columns: new[] { "Id", "IsActive", "Name", "PlatformId" },
                values: new object[,]
                {
                    { 1, true, "5932", 2 },
                    { 2, true, "5933", 2 },
                    { 3, true, "5934", 2 },
                    { 4, true, "5935", 2 },
                    { 5, true, "7601", 3 },
                    { 6, true, "7602", 3 },
                    { 7, true, "5930", 4 },
                    { 8, true, "5921", 4 },
                    { 9, true, "5924", 4 },
                    { 10, true, "5925", 4 },
                    { 11, true, "5926", 4 },
                    { 12, true, "5927", 4 },
                    { 13, true, "5928", 4 },
                    { 14, true, "5937", 4 },
                    { 15, true, "5938", 4 },
                    { 16, true, "8719", 5 },
                    { 17, true, "8720", 5 },
                    { 18, true, "8721", 5 },
                    { 19, true, "8722", 5 },
                    { 20, true, "8723", 5 },
                    { 21, true, "8724", 5 },
                    { 22, true, "8725", 5 },
                    { 23, true, "8726", 5 },
                    { 24, true, "8727", 5 },
                    { 25, true, "8728", 5 },
                    { 26, true, "8729", 5 },
                    { 27, true, "8730", 5 },
                    { 28, true, "8731", 5 },
                    { 29, true, "8732", 5 },
                    { 30, true, "8733", 5 },
                    { 31, true, "8734", 5 },
                    { 32, true, "8735", 5 },
                    { 33, true, "8736", 5 },
                    { 34, true, "8737", 5 },
                    { 35, true, "8738", 5 },
                    { 36, true, "8739", 5 },
                    { 37, true, "8740", 5 },
                    { 38, true, "8745", 6 },
                    { 39, true, "8746", 6 },
                    { 40, true, "8747", 6 },
                    { 41, true, "8748", 6 },
                    { 42, true, "8749", 6 },
                    { 43, true, "8750", 6 },
                    { 44, true, "8751", 6 },
                    { 45, true, "8752", 6 },
                    { 46, true, "8753", 6 },
                    { 47, true, "8754", 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Maintainers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Maintainers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Maintainers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
