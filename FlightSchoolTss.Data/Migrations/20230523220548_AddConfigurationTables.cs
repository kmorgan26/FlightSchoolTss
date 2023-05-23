using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlightSchoolTss.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddConfigurationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lots_Platforms_PlatformId",
                table: "Lots");

            migrationBuilder.DropForeignKey(
                name: "FK_Platforms_Maintainers_MaintainerId",
                table: "Platforms");

            migrationBuilder.DropForeignKey(
                name: "FK_Simulators_Platforms_PlatformId",
                table: "Simulators");

            migrationBuilder.DropTable(
                name: "ManModules");

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 3);

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
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Maintainers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Maintainers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Simulators",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                table: "Simulators",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaintainableId",
                table: "Simulators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Platforms",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MaintainableId",
                table: "Platforms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Maintainers",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Lots",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MaintainableId",
                table: "Lots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HardwareSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maintainables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintainables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HardwareVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HardwareSystemId = table.Column<int>(type: "int", nullable: false),
                    VersionDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareVersions_HardwareSystems",
                        column: x => x.HardwareSystemId,
                        principalTable: "HardwareSystems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigurationItem_ItemTypes",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ManModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintainableId = table.Column<int>(type: "int", nullable: false),
                    LotId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManModules_Lots",
                        column: x => x.LotId,
                        principalTable: "Lots",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManModules_Maintainables",
                        column: x => x.MaintainableId,
                        principalTable: "Maintainables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SoftwareVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    SoftwareSystemId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoftwareVersions_SoftwareSystems",
                        column: x => x.SoftwareSystemId,
                        principalTable: "SoftwareSystems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigurationItemId = table.Column<int>(type: "int", nullable: false),
                    MaintainableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configurations_ConfigurationItem",
                        column: x => x.ConfigurationItemId,
                        principalTable: "ConfigurationItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configurations_Maintainables",
                        column: x => x.MaintainableId,
                        principalTable: "Maintainables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HardwareConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigurationItemId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareConfigurations_ConfigurationItem",
                        column: x => x.ConfigurationItemId,
                        principalTable: "ConfigurationItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SoftwareLoads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigurationItemId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareLoads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoftwareLoads_ConfigurationItem",
                        column: x => x.ConfigurationItemId,
                        principalTable: "ConfigurationItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HardwareVersionsConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HardwareVersionId = table.Column<int>(type: "int", nullable: false),
                    HardwareConfigurationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareVersionsConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareVersionsConfigurations_HardwareConfigurations",
                        column: x => x.HardwareConfigurationId,
                        principalTable: "HardwareConfigurations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HardwareVersionsConfigurations_HardwareVersions",
                        column: x => x.HardwareVersionId,
                        principalTable: "HardwareVersions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SoftwareVersionsLoads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoftwareVersionId = table.Column<int>(type: "int", nullable: false),
                    SoftwareLoadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareVersionsLoads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoftwareVersionsLoads_SoftwareLoads",
                        column: x => x.SoftwareLoadId,
                        principalTable: "SoftwareLoads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SoftwareVersionsLoads_SoftwareVersions",
                        column: x => x.SoftwareVersionId,
                        principalTable: "SoftwareVersions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Simulators_MaintainableId",
                table: "Simulators",
                column: "MaintainableId");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_MaintainableId",
                table: "Platforms",
                column: "MaintainableId");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_MaintainableId",
                table: "Lots",
                column: "MaintainableId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationItem_ItemTypeId",
                table: "ConfigurationItem",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_ConfigurationItemId",
                table: "Configurations",
                column: "ConfigurationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_MaintainableId",
                table: "Configurations",
                column: "MaintainableId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareConfigurations_ConfigurationItemId",
                table: "HardwareConfigurations",
                column: "ConfigurationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareVersions_HardwareSystemId",
                table: "HardwareVersions",
                column: "HardwareSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareVersionsConfigurations_HardwareConfigurationId",
                table: "HardwareVersionsConfigurations",
                column: "HardwareConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareVersionsConfigurations_HardwareVersionId",
                table: "HardwareVersionsConfigurations",
                column: "HardwareVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_ManModules_LotId",
                table: "ManModules",
                column: "LotId");

            migrationBuilder.CreateIndex(
                name: "IX_ManModules_MaintainableId",
                table: "ManModules",
                column: "MaintainableId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareLoads_ConfigurationItemId",
                table: "SoftwareLoads",
                column: "ConfigurationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareVersions_SoftwareSystemId",
                table: "SoftwareVersions",
                column: "SoftwareSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareVersionsLoads_SoftwareLoadId",
                table: "SoftwareVersionsLoads",
                column: "SoftwareLoadId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareVersionsLoads_SoftwareVersionId",
                table: "SoftwareVersionsLoads",
                column: "SoftwareVersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_Maintainables",
                table: "Lots",
                column: "MaintainableId",
                principalTable: "Maintainables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_Platforms",
                table: "Lots",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Platforms_Maintainables",
                table: "Platforms",
                column: "MaintainableId",
                principalTable: "Maintainables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Platforms_Maintainers",
                table: "Platforms",
                column: "MaintainerId",
                principalTable: "Maintainers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Simulators_Maintainables",
                table: "Simulators",
                column: "MaintainableId",
                principalTable: "Maintainables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Simulators_Platforms",
                table: "Simulators",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lots_Maintainables",
                table: "Lots");

            migrationBuilder.DropForeignKey(
                name: "FK_Lots_Platforms",
                table: "Lots");

            migrationBuilder.DropForeignKey(
                name: "FK_Platforms_Maintainables",
                table: "Platforms");

            migrationBuilder.DropForeignKey(
                name: "FK_Platforms_Maintainers",
                table: "Platforms");

            migrationBuilder.DropForeignKey(
                name: "FK_Simulators_Maintainables",
                table: "Simulators");

            migrationBuilder.DropForeignKey(
                name: "FK_Simulators_Platforms",
                table: "Simulators");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "HardwareVersionsConfigurations");

            migrationBuilder.DropTable(
                name: "ManModules");

            migrationBuilder.DropTable(
                name: "SoftwareVersionsLoads");

            migrationBuilder.DropTable(
                name: "HardwareConfigurations");

            migrationBuilder.DropTable(
                name: "HardwareVersions");

            migrationBuilder.DropTable(
                name: "Maintainables");

            migrationBuilder.DropTable(
                name: "SoftwareLoads");

            migrationBuilder.DropTable(
                name: "SoftwareVersions");

            migrationBuilder.DropTable(
                name: "HardwareSystems");

            migrationBuilder.DropTable(
                name: "ConfigurationItem");

            migrationBuilder.DropTable(
                name: "SoftwareSystems");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropIndex(
                name: "IX_Simulators_MaintainableId",
                table: "Simulators");

            migrationBuilder.DropIndex(
                name: "IX_Platforms_MaintainableId",
                table: "Platforms");

            migrationBuilder.DropIndex(
                name: "IX_Lots_MaintainableId",
                table: "Lots");

            migrationBuilder.DropColumn(
                name: "MaintainableId",
                table: "Simulators");

            migrationBuilder.DropColumn(
                name: "MaintainableId",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "MaintainableId",
                table: "Lots");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Simulators",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                table: "Simulators",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Platforms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Maintainers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Lots",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

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

            migrationBuilder.InsertData(
                table: "Maintainers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Flight Safety" },
                    { 2, "L3Harris" },
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
                    { 7, true, 1, "UH-72CPT" },
                    { 8, true, 2, "RCTD" }
                });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "Name", "PlatformId" },
                values: new object[,]
                {
                    { 1, "Lot 1", 8 },
                    { 2, "Lot 2", 8 },
                    { 3, "Lot 3", 8 }
                });

            migrationBuilder.InsertData(
                table: "Simulators",
                columns: new[] { "Id", "Alias", "IsActive", "Name", "PlatformId" },
                values: new object[,]
                {
                    { 1, null, true, "5932", 2 },
                    { 2, null, true, "5933", 2 },
                    { 3, null, true, "5934", 2 },
                    { 4, null, true, "5935", 2 },
                    { 5, null, true, "7601", 3 },
                    { 6, null, true, "7602", 3 },
                    { 7, null, true, "5930", 4 },
                    { 8, null, true, "5921", 4 },
                    { 9, null, true, "5924", 4 },
                    { 10, null, true, "5925", 4 },
                    { 11, null, true, "5926", 4 },
                    { 12, null, true, "5927", 4 },
                    { 13, null, true, "5928", 4 },
                    { 14, null, true, "5937", 4 },
                    { 15, null, true, "5938", 4 },
                    { 16, null, true, "8719", 5 },
                    { 17, null, true, "8720", 5 },
                    { 18, null, true, "8721", 5 },
                    { 19, null, true, "8722", 5 },
                    { 20, null, true, "8723", 5 },
                    { 21, null, true, "8724", 5 },
                    { 22, null, true, "8725", 5 },
                    { 23, null, true, "8726", 5 },
                    { 24, null, true, "8727", 5 },
                    { 25, null, true, "8728", 5 },
                    { 26, null, true, "8729", 5 },
                    { 27, null, true, "8730", 5 },
                    { 28, null, true, "8731", 5 },
                    { 29, null, true, "8732", 5 },
                    { 30, null, true, "8733", 5 },
                    { 31, null, true, "8734", 5 },
                    { 32, null, true, "8735", 5 },
                    { 33, null, true, "8736", 5 },
                    { 34, null, true, "8737", 5 },
                    { 35, null, true, "8738", 5 },
                    { 36, null, true, "8739", 5 },
                    { 37, null, true, "8740", 5 },
                    { 38, null, true, "8745", 6 },
                    { 39, null, true, "8746", 6 },
                    { 40, null, true, "8747", 6 },
                    { 41, null, true, "8748", 6 },
                    { 42, null, true, "8749", 6 },
                    { 43, null, true, "8750", 6 },
                    { 44, null, true, "8751", 6 },
                    { 45, null, true, "8752", 6 },
                    { 46, null, true, "8753", 6 },
                    { 47, null, true, "8754", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManModule_LotId",
                table: "ManModule",
                column: "LotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_Platforms_PlatformId",
                table: "Lots",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Platforms_Maintainers_MaintainerId",
                table: "Platforms",
                column: "MaintainerId",
                principalTable: "Maintainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Simulators_Platforms_PlatformId",
                table: "Simulators",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
