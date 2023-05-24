using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightSchoolTss.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToMaintainable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Maintainables",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Maintainables");
        }
    }
}
