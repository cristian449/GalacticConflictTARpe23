using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterGalacticConflict.Data.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilesToDatabase",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ShipID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesToDatabase", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipStatus = table.Column<int>(type: "int", nullable: false),
                    ShipClass = table.Column<int>(type: "int", nullable: false),
                    ShipHP = table.Column<int>(type: "int", nullable: false),
                    ShipExperience = table.Column<int>(type: "int", nullable: false),
                    TurbolaserPower = table.Column<int>(type: "int", nullable: false),
                    Turbolaser = table.Column<int>(type: "int", nullable: false),
                    MissilePower = table.Column<int>(type: "int", nullable: false),
                    Missile = table.Column<int>(type: "int", nullable: false),
                    TorpedoPower = table.Column<int>(type: "int", nullable: false),
                    Torpedo = table.Column<int>(type: "int", nullable: false),
                    Light_LaserPower = table.Column<int>(type: "int", nullable: false),
                    Light_Laser = table.Column<int>(type: "int", nullable: false),
                    Heavy_LaserPower = table.Column<int>(type: "int", nullable: false),
                    Heavy_Laser = table.Column<int>(type: "int", nullable: false),
                    BallisticPower = table.Column<int>(type: "int", nullable: false),
                    Ballistic = table.Column<int>(type: "int", nullable: false),
                    ShipCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipDestroyed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilesToDatabase");

            migrationBuilder.DropTable(
                name: "Ships");
        }
    }
}
