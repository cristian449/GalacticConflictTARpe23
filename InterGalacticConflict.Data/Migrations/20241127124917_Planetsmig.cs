using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterGalacticConflict.Data.Migrations
{
    /// <inheritdoc />
    public partial class Planetsmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanetType = table.Column<int>(type: "int", nullable: false),
                    PlanetStatus = table.Column<int>(type: "int", nullable: false),
                    PlanetPopulation = table.Column<int>(type: "int", nullable: false),
                    Planetinfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GalaxyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Major_cities = table.Column<int>(type: "int", nullable: false),
                    CapitalCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountOfShipsonPlanet = table.Column<int>(type: "int", nullable: false),
                    SpaceStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpaceStationType = table.Column<int>(type: "int", nullable: false),
                    DefenseType = table.Column<int>(type: "int", nullable: false),
                    DefensePower = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
