using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightSchoolTss.Data.Migrations
{
    /// <inheritdoc />
    public partial class MaintainableKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaintainableId",
                table: "SoftwareSystems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaintainableId",
                table: "HardwareSystems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareSystems_MaintainableId",
                table: "SoftwareSystems",
                column: "MaintainableId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareSystems_MaintainableId",
                table: "HardwareSystems",
                column: "MaintainableId");

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareSystems_Maintainables",
                table: "HardwareSystems",
                column: "MaintainableId",
                principalTable: "Maintainables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareSystems_Maintainables",
                table: "SoftwareSystems",
                column: "MaintainableId",
                principalTable: "Maintainables",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HardwareSystems_Maintainables",
                table: "HardwareSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareSystems_Maintainables",
                table: "SoftwareSystems");

            migrationBuilder.DropIndex(
                name: "IX_SoftwareSystems_MaintainableId",
                table: "SoftwareSystems");

            migrationBuilder.DropIndex(
                name: "IX_HardwareSystems_MaintainableId",
                table: "HardwareSystems");

            migrationBuilder.DropColumn(
                name: "MaintainableId",
                table: "SoftwareSystems");

            migrationBuilder.DropColumn(
                name: "MaintainableId",
                table: "HardwareSystems");
        }
    }
}
