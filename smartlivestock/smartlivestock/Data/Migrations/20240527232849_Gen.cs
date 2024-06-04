using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace smartlivestock.Data.Migrations
{
    public partial class Gen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GenName",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenName",
                table: "Medicines");
        }
    }
}
