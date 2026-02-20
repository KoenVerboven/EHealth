using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKmfSoft_EHealth_API.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientMedicalRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_PatientSurgery_PatientSurgeryId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientAllergies_PatientHealthHistory_PatientHealthHistoryId",
                table: "PatientAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicationHistory_PatientHealthHistory_PatientHealthHistoryId",
                table: "PatientMedicationHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientScan_PatientHealthHistory_PatientHealthHistoryId",
                table: "PatientScan");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientSurgery_PatientHealthHistory_PatientHealthHistoryId",
                table: "PatientSurgery");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientVaccination_PatientHealthHistory_PatientHealthHistoryId",
                table: "PatientVaccination");

            migrationBuilder.DropTable(
                name: "PatientHealthHistory");

            migrationBuilder.DropIndex(
                name: "IX_PatientAllergies_PatientHealthHistoryId",
                table: "PatientAllergies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientVaccination",
                table: "PatientVaccination");

            migrationBuilder.DropIndex(
                name: "IX_PatientVaccination_PatientHealthHistoryId",
                table: "PatientVaccination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientSurgery",
                table: "PatientSurgery");

            migrationBuilder.DropIndex(
                name: "IX_PatientSurgery_PatientHealthHistoryId",
                table: "PatientSurgery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientScan",
                table: "PatientScan");

            migrationBuilder.DropIndex(
                name: "IX_PatientScan_PatientHealthHistoryId",
                table: "PatientScan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientMedicationHistory",
                table: "PatientMedicationHistory");

            migrationBuilder.DropIndex(
                name: "IX_PatientMedicationHistory_PatientHealthHistoryId",
                table: "PatientMedicationHistory");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PatientAllergies");

            migrationBuilder.DropColumn(
                name: "PatientHealthHistoryId",
                table: "PatientAllergies");

            migrationBuilder.DropColumn(
                name: "PatientHealthHistoryId",
                table: "PatientVaccination");

            migrationBuilder.DropColumn(
                name: "PatientHealthHistoryId",
                table: "PatientSurgery");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PatientSurgery");

            migrationBuilder.DropColumn(
                name: "PatientHealthHistoryId",
                table: "PatientScan");

            migrationBuilder.DropColumn(
                name: "PatientHealthHistoryId",
                table: "PatientMedicationHistory");

            migrationBuilder.RenameTable(
                name: "PatientVaccination",
                newName: "PatientVaccinations");

            migrationBuilder.RenameTable(
                name: "PatientSurgery",
                newName: "PatientSurgeries");

            migrationBuilder.RenameTable(
                name: "PatientScan",
                newName: "PatientScans");

            migrationBuilder.RenameTable(
                name: "PatientMedicationHistory",
                newName: "PatientMedications");

            migrationBuilder.RenameColumn(
                name: "PatientMedicalHistoryId",
                table: "PatientAllergies",
                newName: "PatientMedicalRecordId");

            migrationBuilder.RenameColumn(
                name: "PatientMedicalHistoryId",
                table: "PatientVaccinations",
                newName: "PatientMedicalRecordId");

            migrationBuilder.RenameColumn(
                name: "PatientMedicalHistoryId",
                table: "PatientSurgeries",
                newName: "PatientMedicalRecordId");

            migrationBuilder.RenameColumn(
                name: "PatientMedicalHistoryId",
                table: "PatientScans",
                newName: "PatientMedicalRecordId");

            migrationBuilder.RenameColumn(
                name: "PatientMedicalHistoryId",
                table: "PatientMedications",
                newName: "PatientMedicalRecordId");

            migrationBuilder.AddColumn<int>(
                name: "AllergyId",
                table: "PatientAllergies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "PatientAllergies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reaction",
                table: "PatientAllergies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecordedDate",
                table: "PatientAllergies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "SeverityId",
                table: "PatientAllergies",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "StatusId",
                table: "PatientAllergies",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientVaccinations",
                table: "PatientVaccinations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientSurgeries",
                table: "PatientSurgeries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientScans",
                table: "PatientScans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientMedications",
                table: "PatientMedications",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PatientLabResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientMedicalRecordId = table.Column<int>(type: "int", nullable: false),
                    LabExamKind = table.Column<int>(type: "int", nullable: false),
                    LabResult = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientLabResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientMedicalRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergies_PatientMedicalRecordId",
                table: "PatientAllergies",
                column: "PatientMedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVaccinations_PatientMedicalRecordId",
                table: "PatientVaccinations",
                column: "PatientMedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSurgeries_PatientMedicalRecordId",
                table: "PatientSurgeries",
                column: "PatientMedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientScans_PatientMedicalRecordId",
                table: "PatientScans",
                column: "PatientMedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedications_PatientMedicalRecordId",
                table: "PatientMedications",
                column: "PatientMedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalRecords_PatientId",
                table: "PatientMedicalRecords",
                column: "PatientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_PatientSurgeries_PatientSurgeryId",
                table: "Doctors",
                column: "PatientSurgeryId",
                principalTable: "PatientSurgeries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAllergies_PatientMedicalRecords_PatientMedicalRecordId",
                table: "PatientAllergies",
                column: "PatientMedicalRecordId",
                principalTable: "PatientMedicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedications_PatientMedicalRecords_PatientMedicalRecordId",
                table: "PatientMedications",
                column: "PatientMedicalRecordId",
                principalTable: "PatientMedicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientScans_PatientMedicalRecords_PatientMedicalRecordId",
                table: "PatientScans",
                column: "PatientMedicalRecordId",
                principalTable: "PatientMedicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientSurgeries_PatientMedicalRecords_PatientMedicalRecordId",
                table: "PatientSurgeries",
                column: "PatientMedicalRecordId",
                principalTable: "PatientMedicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientVaccinations_PatientMedicalRecords_PatientMedicalRecordId",
                table: "PatientVaccinations",
                column: "PatientMedicalRecordId",
                principalTable: "PatientMedicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_PatientSurgeries_PatientSurgeryId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientAllergies_PatientMedicalRecords_PatientMedicalRecordId",
                table: "PatientAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedications_PatientMedicalRecords_PatientMedicalRecordId",
                table: "PatientMedications");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientScans_PatientMedicalRecords_PatientMedicalRecordId",
                table: "PatientScans");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientSurgeries_PatientMedicalRecords_PatientMedicalRecordId",
                table: "PatientSurgeries");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientVaccinations_PatientMedicalRecords_PatientMedicalRecordId",
                table: "PatientVaccinations");

            migrationBuilder.DropTable(
                name: "PatientLabResults");

            migrationBuilder.DropTable(
                name: "PatientMedicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_PatientAllergies_PatientMedicalRecordId",
                table: "PatientAllergies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientVaccinations",
                table: "PatientVaccinations");

            migrationBuilder.DropIndex(
                name: "IX_PatientVaccinations_PatientMedicalRecordId",
                table: "PatientVaccinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientSurgeries",
                table: "PatientSurgeries");

            migrationBuilder.DropIndex(
                name: "IX_PatientSurgeries_PatientMedicalRecordId",
                table: "PatientSurgeries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientScans",
                table: "PatientScans");

            migrationBuilder.DropIndex(
                name: "IX_PatientScans_PatientMedicalRecordId",
                table: "PatientScans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientMedications",
                table: "PatientMedications");

            migrationBuilder.DropIndex(
                name: "IX_PatientMedications_PatientMedicalRecordId",
                table: "PatientMedications");

            migrationBuilder.DropColumn(
                name: "AllergyId",
                table: "PatientAllergies");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "PatientAllergies");

            migrationBuilder.DropColumn(
                name: "Reaction",
                table: "PatientAllergies");

            migrationBuilder.DropColumn(
                name: "RecordedDate",
                table: "PatientAllergies");

            migrationBuilder.DropColumn(
                name: "SeverityId",
                table: "PatientAllergies");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "PatientAllergies");

            migrationBuilder.RenameTable(
                name: "PatientVaccinations",
                newName: "PatientVaccination");

            migrationBuilder.RenameTable(
                name: "PatientSurgeries",
                newName: "PatientSurgery");

            migrationBuilder.RenameTable(
                name: "PatientScans",
                newName: "PatientScan");

            migrationBuilder.RenameTable(
                name: "PatientMedications",
                newName: "PatientMedicationHistory");

            migrationBuilder.RenameColumn(
                name: "PatientMedicalRecordId",
                table: "PatientAllergies",
                newName: "PatientMedicalHistoryId");

            migrationBuilder.RenameColumn(
                name: "PatientMedicalRecordId",
                table: "PatientVaccination",
                newName: "PatientMedicalHistoryId");

            migrationBuilder.RenameColumn(
                name: "PatientMedicalRecordId",
                table: "PatientSurgery",
                newName: "PatientMedicalHistoryId");

            migrationBuilder.RenameColumn(
                name: "PatientMedicalRecordId",
                table: "PatientScan",
                newName: "PatientMedicalHistoryId");

            migrationBuilder.RenameColumn(
                name: "PatientMedicalRecordId",
                table: "PatientMedicationHistory",
                newName: "PatientMedicalHistoryId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PatientAllergies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PatientHealthHistoryId",
                table: "PatientAllergies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientHealthHistoryId",
                table: "PatientVaccination",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientHealthHistoryId",
                table: "PatientSurgery",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "PatientSurgery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientHealthHistoryId",
                table: "PatientScan",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientHealthHistoryId",
                table: "PatientMedicationHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientVaccination",
                table: "PatientVaccination",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientSurgery",
                table: "PatientSurgery",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientScan",
                table: "PatientScan",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientMedicationHistory",
                table: "PatientMedicationHistory",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PatientHealthHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientHealthHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientHealthHistory_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergies_PatientHealthHistoryId",
                table: "PatientAllergies",
                column: "PatientHealthHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVaccination_PatientHealthHistoryId",
                table: "PatientVaccination",
                column: "PatientHealthHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSurgery_PatientHealthHistoryId",
                table: "PatientSurgery",
                column: "PatientHealthHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientScan_PatientHealthHistoryId",
                table: "PatientScan",
                column: "PatientHealthHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationHistory_PatientHealthHistoryId",
                table: "PatientMedicationHistory",
                column: "PatientHealthHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHealthHistory_PatientId",
                table: "PatientHealthHistory",
                column: "PatientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_PatientSurgery_PatientSurgeryId",
                table: "Doctors",
                column: "PatientSurgeryId",
                principalTable: "PatientSurgery",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAllergies_PatientHealthHistory_PatientHealthHistoryId",
                table: "PatientAllergies",
                column: "PatientHealthHistoryId",
                principalTable: "PatientHealthHistory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicationHistory_PatientHealthHistory_PatientHealthHistoryId",
                table: "PatientMedicationHistory",
                column: "PatientHealthHistoryId",
                principalTable: "PatientHealthHistory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientScan_PatientHealthHistory_PatientHealthHistoryId",
                table: "PatientScan",
                column: "PatientHealthHistoryId",
                principalTable: "PatientHealthHistory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientSurgery_PatientHealthHistory_PatientHealthHistoryId",
                table: "PatientSurgery",
                column: "PatientHealthHistoryId",
                principalTable: "PatientHealthHistory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientVaccination_PatientHealthHistory_PatientHealthHistoryId",
                table: "PatientVaccination",
                column: "PatientHealthHistoryId",
                principalTable: "PatientHealthHistory",
                principalColumn: "Id");
        }
    }
}
