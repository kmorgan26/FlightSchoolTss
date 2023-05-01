using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiTraining.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Simulators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lots_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LotId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManModule_Lots_LotId",
                        column: x => x.LotId,
                        principalTable: "Lots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Maintainers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "L3Harris");

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "IsActive", "MaintainerId", "Name" },
                values: new object[] { 8, true, 2, "RCTD" });

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 1,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 2,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 3,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 4,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 5,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 6,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 7,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 8,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 9,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 10,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 11,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 12,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 13,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 14,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 15,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 16,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 17,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 18,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 19,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 20,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 21,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 22,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 23,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 24,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 25,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 26,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 27,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 28,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 29,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 30,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 31,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 32,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 33,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 34,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 35,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 36,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 37,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 38,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 39,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 40,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 41,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 42,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 43,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 44,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 45,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 46,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                table: "Simulators",
                keyColumn: "Id",
                keyValue: 47,
                column: "Alias",
                value: null);

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "Name", "PlatformId" },
                values: new object[,]
                {
                    { 1, "Lot 1", 8 },
                    { 2, "Lot 2", 8 },
                    { 3, "Lot 3", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lots_PlatformId",
                table: "Lots",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_ManModule_LotId",
                table: "ManModule",
                column: "LotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManModule");

            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Simulators");

            migrationBuilder.UpdateData(
                table: "Maintainers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "CAE");
        }
    }
}
