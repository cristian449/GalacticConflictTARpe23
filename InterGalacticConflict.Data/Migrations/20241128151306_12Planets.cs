using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterGalacticConflict.Data.Migrations
{
    /// <inheritdoc />
    public partial class _12Planets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanetStatus",
                table: "Planets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanetStatus",
                table: "Planets",
                type: "int",
                nullable: true);
        }
    }
}
