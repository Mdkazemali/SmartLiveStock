using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace smartlivestock.Data.Migrations
{
    public partial class ShortNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AditionalNotes",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Prescription",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DurationType",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShortNotePresId",
                table: "Prescription",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediType",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShortNotes",
                columns: table => new
                {
                    ShortId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortNoteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SrUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortNotes", x => x.ShortId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_ShortNotePresId",
                table: "Prescription",
                column: "ShortNotePresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_ShortNotes_ShortNotePresId",
                table: "Prescription",
                column: "ShortNotePresId",
                principalTable: "ShortNotes",
                principalColumn: "ShortId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_ShortNotes_ShortNotePresId",
                table: "Prescription");

            migrationBuilder.DropTable(
                name: "ShortNotes");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_ShortNotePresId",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "AditionalNotes",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "DurationType",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "ShortNotePresId",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "MediType",
                table: "Medicines");
        }
    }
}
