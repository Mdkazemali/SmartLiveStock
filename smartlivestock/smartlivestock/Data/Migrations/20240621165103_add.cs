using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace smartlivestock.Data.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeOfAge",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfAge",
                table: "Prescription");
        }
    }
}
