using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightSchoolTss.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintainables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maintainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintainers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigurationItems_ItemTypes",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HardwareSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintainableId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareSystems_Maintainables",
                        column: x => x.MaintainableId,
                        principalTable: "Maintainables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SoftwareSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintainableId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoftwareSystems_Maintainables",
                        column: x => x.MaintainableId,
                        principalTable: "Maintainables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintainerId = table.Column<int>(type: "int", nullable: false),
                    MaintainableId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Platforms_Maintainables",
                        column: x => x.MaintainableId,
                        principalTable: "Maintainables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Platforms_Maintainers",
                        column: x => x.MaintainerId,
                        principalTable: "Maintainers",
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
                        name: "FK_Configurations_ConfigurationItems",
                        column: x => x.ConfigurationItemId,
                        principalTable: "ConfigurationItems",
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
                        name: "FK_HardwareConfigurations_ConfigurationItems",
                        column: x => x.ConfigurationItemId,
                        principalTable: "ConfigurationItems",
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
                        name: "FK_SoftwareLoads_ConfigurationItems",
                        column: x => x.ConfigurationItemId,
                        principalTable: "ConfigurationItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HardwareVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "Lots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    MaintainableId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lots_Maintainables",
                        column: x => x.MaintainableId,
                        principalTable: "Maintainables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lots_Platforms",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Simulators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MaintainableId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Simulators_Maintainables",
                        column: x => x.MaintainableId,
                        principalTable: "Maintainables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Simulators_Platforms",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
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

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationItems_ItemTypeId",
                table: "ConfigurationItems",
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
                name: "IX_HardwareSystems_MaintainableId",
                table: "HardwareSystems",
                column: "MaintainableId");

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
                name: "IX_Lots_MaintainableId",
                table: "Lots",
                column: "MaintainableId");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_PlatformId",
                table: "Lots",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_ManModules_LotId",
                table: "ManModules",
                column: "LotId");

            migrationBuilder.CreateIndex(
                name: "IX_ManModules_MaintainableId",
                table: "ManModules",
                column: "MaintainableId");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_MaintainableId",
                table: "Platforms",
                column: "MaintainableId");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_MaintainerId",
                table: "Platforms",
                column: "MaintainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Simulators_MaintainableId",
                table: "Simulators",
                column: "MaintainableId");

            migrationBuilder.CreateIndex(
                name: "IX_Simulators_PlatformId",
                table: "Simulators",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareLoads_ConfigurationItemId",
                table: "SoftwareLoads",
                column: "ConfigurationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareSystems_MaintainableId",
                table: "SoftwareSystems",
                column: "MaintainableId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "HardwareVersionsConfigurations");

            migrationBuilder.DropTable(
                name: "ManModules");

            migrationBuilder.DropTable(
                name: "Simulators");

            migrationBuilder.DropTable(
                name: "SoftwareVersionsLoads");

            migrationBuilder.DropTable(
                name: "HardwareConfigurations");

            migrationBuilder.DropTable(
                name: "HardwareVersions");

            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "SoftwareLoads");

            migrationBuilder.DropTable(
                name: "SoftwareVersions");

            migrationBuilder.DropTable(
                name: "HardwareSystems");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "ConfigurationItems");

            migrationBuilder.DropTable(
                name: "SoftwareSystems");

            migrationBuilder.DropTable(
                name: "Maintainers");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "Maintainables");
        }
    }
}
