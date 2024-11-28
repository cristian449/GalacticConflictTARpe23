using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterGalacticConflict.Data.Migrations
{
    /// <inheritdoc />
    public partial class _12PlanetsS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CapitalCity",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AmountOfShipsonPlanet",
                table: "Planets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpaceStation",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SpaceStationType",
                table: "Planets",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpaceStation",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "SpaceStationType",
                table: "Planets");

            migrationBuilder.AlterColumn<string>(
                name: "CapitalCity",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AmountOfShipsonPlanet",
                table: "Planets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
