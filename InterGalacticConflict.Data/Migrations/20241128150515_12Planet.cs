using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterGalacticConflict.Data.Migrations
{
    /// <inheritdoc />
    public partial class _12Planet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefensePower",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "DefenseType",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "Planetinfo",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "SpaceStation",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "SpaceStationType",
                table: "Planets");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Planets",
                newName: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Planets",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "DefensePower",
                table: "Planets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefenseType",
                table: "Planets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Planetinfo",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpaceStation",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpaceStationType",
                table: "Planets",
                type: "int",
                nullable: true);
        }
    }
}
