using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace smartlivestock.Data.Migrations
{
    public partial class FacilityRegistri : Migration
    {
        public string FalPhotoUrl { get; internal set; }
        public object FalProfilePhoto { get; internal set; }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacilityRegistryId",
                table: "UserInformation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FacilityRegistry",
                columns: table => new
                {
                    FacilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacilityEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacilityMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacilityHeadInfomations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DivisionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistricName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityCorporationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpozillaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FaUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FalPhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FarPhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityRegistry", x => x.FacilityId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInformation_FacilityRegistryId",
                table: "UserInformation",
                column: "FacilityRegistryId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInformation_FacilityRegistry_FacilityRegistryId",
                table: "UserInformation",
                column: "FacilityRegistryId",
                principalTable: "FacilityRegistry",
                principalColumn: "FacilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInformation_FacilityRegistry_FacilityRegistryId",
                table: "UserInformation");

            migrationBuilder.DropTable(
                name: "FacilityRegistry");

            migrationBuilder.DropIndex(
                name: "IX_UserInformation_FacilityRegistryId",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "FacilityRegistryId",
                table: "UserInformation");
        }

       
    }
}
