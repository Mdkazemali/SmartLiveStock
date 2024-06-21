using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace smartlivestock.Data.Migrations
{
    public partial class SpeciesDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpeciesAges",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SpeciesGender",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpeciesId",
                table: "Prescription",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpeciesQuentity",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeciesName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpeciesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.SpeciesId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_SpeciesId",
                table: "Prescription",
                column: "SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Species_SpeciesId",
                table: "Prescription",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "SpeciesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Species_SpeciesId",
                table: "Prescription");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_SpeciesId",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "SpeciesAges",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "SpeciesGender",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "SpeciesId",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "SpeciesQuentity",
                table: "Prescription");
        }
    }
}
