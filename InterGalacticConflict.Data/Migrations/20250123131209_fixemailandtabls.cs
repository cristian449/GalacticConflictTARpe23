using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterGalacticConflict.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixemailandtabls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Planets",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "BasicResource",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "Credits",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "CurrentStatus",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "PlanetLocation",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "PlanetResouces",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "PlanetStatus",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "ProfileAttributedToAnAccountUserAt",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "ProfileCreatedAt",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "ProfileModifiedAt",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "ProfileStatusLastChangedAt",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "ProfileType",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "ScreenName",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "Victories",
                table: "Planets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planets",
                table: "Planets",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "PlayerProfiles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScreenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    BasicResource = table.Column<int>(type: "int", nullable: false),
                    Victories = table.Column<int>(type: "int", nullable: false),
                    CurrentStatus = table.Column<int>(type: "int", nullable: false),
                    ProfileType = table.Column<bool>(type: "bit", nullable: false),
                    ProfileCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileAttributedToAnAccountUserAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileStatusLastChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerProfiles", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planets",
                table: "Planets");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Planets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BasicResource",
                table: "Planets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Credits",
                table: "Planets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentStatus",
                table: "Planets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PlanetLocation",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PlanetResouces",
                table: "Planets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanetStatus",
                table: "Planets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProfileAttributedToAnAccountUserAt",
                table: "Planets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ProfileCreatedAt",
                table: "Planets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ProfileModifiedAt",
                table: "Planets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ProfileStatusLastChangedAt",
                table: "Planets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "ProfileType",
                table: "Planets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ScreenName",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Victories",
                table: "Planets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planets",
                table: "Planets",
                column: "Id");
        }
    }
}
