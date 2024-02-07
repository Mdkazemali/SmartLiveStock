using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace smartlivestock.Data.Migrations
{
    public partial class Prescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advices",
                columns: table => new
                {
                    AdvId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdvDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advices", x => x.AdvId);
                });

            migrationBuilder.CreateTable(
                name: "ChiefComplaint",
                columns: table => new
                {
                    ChiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChiName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiefComplaint", x => x.ChiId);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    DiagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.DiagId);
                });

            migrationBuilder.CreateTable(
                name: "Doses",
                columns: table => new
                {
                    DosesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Morning = table.Column<bool>(type: "bit", nullable: false),
                    Afternoon = table.Column<bool>(type: "bit", nullable: false),
                    Evening = table.Column<bool>(type: "bit", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    DosesName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doses", x => x.DosesId);
                });

            migrationBuilder.CreateTable(
                name: "FlowUp",
                columns: table => new
                {
                    FloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowUp", x => x.FloId);
                });

            migrationBuilder.CreateTable(
                name: "GeneralExamination",
                columns: table => new
                {
                    GenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralExamination", x => x.GenId);
                });

            migrationBuilder.CreateTable(
                name: "Invastigations",
                columns: table => new
                {
                    InvId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invastigations", x => x.InvId);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedId);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    RegiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PtnId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDAte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.RegiId);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    PresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationId = table.Column<int>(type: "int", nullable: false),
                    ChiefComplaintId = table.Column<int>(type: "int", nullable: false),
                    GeneralExaminationId = table.Column<int>(type: "int", nullable: false),
                    DiagnosisId = table.Column<int>(type: "int", nullable: false),
                    InvastigationId = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    DosesId = table.Column<int>(type: "int", nullable: false),
                    AdviceId = table.Column<int>(type: "int", nullable: false),
                    FlowUpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.PresId);
                    table.ForeignKey(
                        name: "FK_Prescription_Advices_AdviceId",
                        column: x => x.AdviceId,
                        principalTable: "Advices",
                        principalColumn: "AdvId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_ChiefComplaint_ChiefComplaintId",
                        column: x => x.ChiefComplaintId,
                        principalTable: "ChiefComplaint",
                        principalColumn: "ChiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Diagnosis_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnosis",
                        principalColumn: "DiagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Doses_DosesId",
                        column: x => x.DosesId,
                        principalTable: "Doses",
                        principalColumn: "DosesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_FlowUp_FlowUpId",
                        column: x => x.FlowUpId,
                        principalTable: "FlowUp",
                        principalColumn: "FloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_GeneralExamination_GeneralExaminationId",
                        column: x => x.GeneralExaminationId,
                        principalTable: "GeneralExamination",
                        principalColumn: "GenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Invastigations_InvastigationId",
                        column: x => x.InvastigationId,
                        principalTable: "Invastigations",
                        principalColumn: "InvId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Registration_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_AdviceId",
                table: "Prescription",
                column: "AdviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_ChiefComplaintId",
                table: "Prescription",
                column: "ChiefComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_DiagnosisId",
                table: "Prescription",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_DosesId",
                table: "Prescription",
                column: "DosesId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_FlowUpId",
                table: "Prescription",
                column: "FlowUpId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_GeneralExaminationId",
                table: "Prescription",
                column: "GeneralExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_InvastigationId",
                table: "Prescription",
                column: "InvastigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_MedicineId",
                table: "Prescription",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_RegistrationId",
                table: "Prescription",
                column: "RegistrationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Advices");

            migrationBuilder.DropTable(
                name: "ChiefComplaint");

            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "Doses");

            migrationBuilder.DropTable(
                name: "FlowUp");

            migrationBuilder.DropTable(
                name: "GeneralExamination");

            migrationBuilder.DropTable(
                name: "Invastigations");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Registration");
        }
    }
}
