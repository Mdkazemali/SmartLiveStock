using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace smartlivestock.Data.Migrations
{
    public partial class NewHeading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bkash",
                table: "UserInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designations",
                table: "UserInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailNo",
                table: "UserInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "UserInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Institute",
                table: "UserInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NagadNo",
                table: "UserInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassingYear",
                table: "UserInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresentAddrss",
                table: "UserInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Roket",
                table: "UserInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "UserInformation",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bkash",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "Designations",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "EmailNo",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "Institute",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "NagadNo",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "PassingYear",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "PresentAddrss",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "Roket",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "UserInformation");
        }
    }
}
