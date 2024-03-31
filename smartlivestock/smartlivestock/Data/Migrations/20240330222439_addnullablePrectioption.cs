using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace smartlivestock.Data.Migrations
{
    public partial class addnullablePrectioption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Advices_AdviceId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_ChiefComplaint_ChiefComplaintId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Diagnosis_DiagnosisId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Doses_DosesId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_FlowUp_FlowUpId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_GeneralExamination_GeneralExaminationId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Invastigations_InvastigationId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicines_MedicineId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Registration_RegistrationId",
                table: "Prescription");

            migrationBuilder.AlterColumn<int>(
                name: "RegistrationId",
                table: "Prescription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MedicineId",
                table: "Prescription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InvastigationId",
                table: "Prescription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GeneralExaminationId",
                table: "Prescription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FlowUpId",
                table: "Prescription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DosesId",
                table: "Prescription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DiagnosisId",
                table: "Prescription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ChiefComplaintId",
                table: "Prescription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdviceId",
                table: "Prescription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Advices_AdviceId",
                table: "Prescription",
                column: "AdviceId",
                principalTable: "Advices",
                principalColumn: "AdvId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_ChiefComplaint_ChiefComplaintId",
                table: "Prescription",
                column: "ChiefComplaintId",
                principalTable: "ChiefComplaint",
                principalColumn: "ChiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Diagnosis_DiagnosisId",
                table: "Prescription",
                column: "DiagnosisId",
                principalTable: "Diagnosis",
                principalColumn: "DiagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Doses_DosesId",
                table: "Prescription",
                column: "DosesId",
                principalTable: "Doses",
                principalColumn: "DosesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_FlowUp_FlowUpId",
                table: "Prescription",
                column: "FlowUpId",
                principalTable: "FlowUp",
                principalColumn: "FloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_GeneralExamination_GeneralExaminationId",
                table: "Prescription",
                column: "GeneralExaminationId",
                principalTable: "GeneralExamination",
                principalColumn: "GenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Invastigations_InvastigationId",
                table: "Prescription",
                column: "InvastigationId",
                principalTable: "Invastigations",
                principalColumn: "InvId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicines_MedicineId",
                table: "Prescription",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "MedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Registration_RegistrationId",
                table: "Prescription",
                column: "RegistrationId",
                principalTable: "Registration",
                principalColumn: "RegiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Advices_AdviceId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_ChiefComplaint_ChiefComplaintId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Diagnosis_DiagnosisId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Doses_DosesId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_FlowUp_FlowUpId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_GeneralExamination_GeneralExaminationId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Invastigations_InvastigationId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicines_MedicineId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Registration_RegistrationId",
                table: "Prescription");

            migrationBuilder.AlterColumn<int>(
                name: "RegistrationId",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicineId",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvastigationId",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GeneralExaminationId",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FlowUpId",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DosesId",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiagnosisId",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChiefComplaintId",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdviceId",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Advices_AdviceId",
                table: "Prescription",
                column: "AdviceId",
                principalTable: "Advices",
                principalColumn: "AdvId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_ChiefComplaint_ChiefComplaintId",
                table: "Prescription",
                column: "ChiefComplaintId",
                principalTable: "ChiefComplaint",
                principalColumn: "ChiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Diagnosis_DiagnosisId",
                table: "Prescription",
                column: "DiagnosisId",
                principalTable: "Diagnosis",
                principalColumn: "DiagId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Doses_DosesId",
                table: "Prescription",
                column: "DosesId",
                principalTable: "Doses",
                principalColumn: "DosesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_FlowUp_FlowUpId",
                table: "Prescription",
                column: "FlowUpId",
                principalTable: "FlowUp",
                principalColumn: "FloId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_GeneralExamination_GeneralExaminationId",
                table: "Prescription",
                column: "GeneralExaminationId",
                principalTable: "GeneralExamination",
                principalColumn: "GenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Invastigations_InvastigationId",
                table: "Prescription",
                column: "InvastigationId",
                principalTable: "Invastigations",
                principalColumn: "InvId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicines_MedicineId",
                table: "Prescription",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "MedId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Registration_RegistrationId",
                table: "Prescription",
                column: "RegistrationId",
                principalTable: "Registration",
                principalColumn: "RegiId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
