using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterGalacticConflict.Data.Migrations
{
    /// <inheritdoc />
    public partial class newmigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShipUpdatedAt",
                table: "Ships",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ShipCreatedAt",
                table: "Ships",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Ships",
                newName: "ShipUpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Ships",
                newName: "ShipCreatedAt");
        }
    }
}
