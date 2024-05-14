using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace smartlivestock.Data.Migrations
{
    public partial class Presc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReferredId",
                table: "Prescription",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_ReferredId",
                table: "Prescription",
                column: "ReferredId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_ReferredTo_ReferredId",
                table: "Prescription",
                column: "ReferredId",
                principalTable: "ReferredTo",
                principalColumn: "ReferredId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_ReferredTo_ReferredId",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_ReferredId",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "ReferredId",
                table: "Prescription");
        }
    }
}
