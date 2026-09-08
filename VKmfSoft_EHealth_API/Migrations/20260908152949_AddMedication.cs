using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKmfSoft_EHealth_API.Migrations
{
    /// <inheritdoc />
    public partial class AddMedication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_HospitalDepartments_hospitalDepartmentId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_HospitalDepartments_hospitalDepartmentId",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "MedicationName",
                table: "PatientMedications");

            migrationBuilder.RenameColumn(
                name: "hospitalDepartmentId",
                table: "Nurses",
                newName: "HospitalDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Nurses_hospitalDepartmentId",
                table: "Nurses",
                newName: "IX_Nurses_HospitalDepartmentId");

            migrationBuilder.RenameColumn(
                name: "hospitalDepartmentId",
                table: "Doctors",
                newName: "HospitalDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_hospitalDepartmentId",
                table: "Doctors",
                newName: "IX_Doctors_HospitalDepartmentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "LabRsultDate",
                table: "PatientLabResults",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstructionsForUse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumAge = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicationSideEffect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SideEffect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationSideEffect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationSideEffect_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedications_MedicationId",
                table: "PatientMedications",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationSideEffect_MedicationId",
                table: "MedicationSideEffect",
                column: "MedicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_HospitalDepartments_HospitalDepartmentId",
                table: "Doctors",
                column: "HospitalDepartmentId",
                principalTable: "HospitalDepartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_HospitalDepartments_HospitalDepartmentId",
                table: "Nurses",
                column: "HospitalDepartmentId",
                principalTable: "HospitalDepartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedications_Medications_MedicationId",
                table: "PatientMedications",
                column: "MedicationId",
                principalTable: "Medications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_HospitalDepartments_HospitalDepartmentId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_HospitalDepartments_HospitalDepartmentId",
                table: "Nurses");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedications_Medications_MedicationId",
                table: "PatientMedications");

            migrationBuilder.DropTable(
                name: "MedicationSideEffect");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropIndex(
                name: "IX_PatientMedications_MedicationId",
                table: "PatientMedications");

            migrationBuilder.DropColumn(
                name: "LabRsultDate",
                table: "PatientLabResults");

            migrationBuilder.RenameColumn(
                name: "HospitalDepartmentId",
                table: "Nurses",
                newName: "hospitalDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Nurses_HospitalDepartmentId",
                table: "Nurses",
                newName: "IX_Nurses_hospitalDepartmentId");

            migrationBuilder.RenameColumn(
                name: "HospitalDepartmentId",
                table: "Doctors",
                newName: "hospitalDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_HospitalDepartmentId",
                table: "Doctors",
                newName: "IX_Doctors_hospitalDepartmentId");

            migrationBuilder.AddColumn<string>(
                name: "MedicationName",
                table: "PatientMedications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_HospitalDepartments_hospitalDepartmentId",
                table: "Doctors",
                column: "hospitalDepartmentId",
                principalTable: "HospitalDepartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_HospitalDepartments_hospitalDepartmentId",
                table: "Nurses",
                column: "hospitalDepartmentId",
                principalTable: "HospitalDepartments",
                principalColumn: "Id");
        }
    }
}
