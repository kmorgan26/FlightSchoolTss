using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightSchoolTss.Data.Migrations
{
    /// <inheritdoc />
    public partial class PluralConfigItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfigurationItem_ItemTypes",
                table: "ConfigurationItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Configurations_ConfigurationItem",
                table: "Configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareConfigurations_ConfigurationItem",
                table: "HardwareConfigurations");

            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareLoads_ConfigurationItem",
                table: "SoftwareLoads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigurationItem",
                table: "ConfigurationItem");

            migrationBuilder.RenameTable(
                name: "ConfigurationItem",
                newName: "ConfigurationItems");

            migrationBuilder.RenameIndex(
                name: "IX_ConfigurationItem_ItemTypeId",
                table: "ConfigurationItems",
                newName: "IX_ConfigurationItems_ItemTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigurationItems",
                table: "ConfigurationItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigurationItems_ItemTypes",
                table: "ConfigurationItems",
                column: "ItemTypeId",
                principalTable: "ItemTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Configurations_ConfigurationItems",
                table: "Configurations",
                column: "ConfigurationItemId",
                principalTable: "ConfigurationItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareConfigurations_ConfigurationItems",
                table: "HardwareConfigurations",
                column: "ConfigurationItemId",
                principalTable: "ConfigurationItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareLoads_ConfigurationItems",
                table: "SoftwareLoads",
                column: "ConfigurationItemId",
                principalTable: "ConfigurationItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfigurationItems_ItemTypes",
                table: "ConfigurationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Configurations_ConfigurationItems",
                table: "Configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareConfigurations_ConfigurationItems",
                table: "HardwareConfigurations");

            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareLoads_ConfigurationItems",
                table: "SoftwareLoads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigurationItems",
                table: "ConfigurationItems");

            migrationBuilder.RenameTable(
                name: "ConfigurationItems",
                newName: "ConfigurationItem");

            migrationBuilder.RenameIndex(
                name: "IX_ConfigurationItems_ItemTypeId",
                table: "ConfigurationItem",
                newName: "IX_ConfigurationItem_ItemTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigurationItem",
                table: "ConfigurationItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigurationItem_ItemTypes",
                table: "ConfigurationItem",
                column: "ItemTypeId",
                principalTable: "ItemTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Configurations_ConfigurationItem",
                table: "Configurations",
                column: "ConfigurationItemId",
                principalTable: "ConfigurationItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareConfigurations_ConfigurationItem",
                table: "HardwareConfigurations",
                column: "ConfigurationItemId",
                principalTable: "ConfigurationItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareLoads_ConfigurationItem",
                table: "SoftwareLoads",
                column: "ConfigurationItemId",
                principalTable: "ConfigurationItem",
                principalColumn: "Id");
        }
    }
}
