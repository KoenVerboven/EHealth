using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKmfSoft_EHealth_API.Migrations
{
    /// <inheritdoc />
    public partial class RemoevHospitalEmployeeAsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_HospitalEmployees_HospitalEmployeeId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAppointments_HospitalEmployees_DoctorId",
                table: "DoctorAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalEmployees_HospitalDepartments_hospitalDepartmentId",
                table: "HospitalEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalEmployees_PatientSurgeries_PatientSurgeryId",
                table: "HospitalEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalEmployees",
                table: "HospitalEmployees");

            migrationBuilder.DropIndex(
                name: "IX_HospitalEmployees_PatientSurgeryId",
                table: "HospitalEmployees");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "HospitalEmployees");

            migrationBuilder.DropColumn(
                name: "LicenseNumber",
                table: "HospitalEmployees");

            migrationBuilder.DropColumn(
                name: "LicenseValidUntil",
                table: "HospitalEmployees");

            migrationBuilder.DropColumn(
                name: "MedicalTitle",
                table: "HospitalEmployees");

            migrationBuilder.DropColumn(
                name: "PatientSurgeryId",
                table: "HospitalEmployees");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "HospitalEmployees");

            migrationBuilder.RenameTable(
                name: "HospitalEmployees",
                newName: "Nurses");

            migrationBuilder.RenameColumn(
                name: "HospitalEmployeeId",
                table: "Addresses",
                newName: "NurseId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_HospitalEmployeeId",
                table: "Addresses",
                newName: "IX_Addresses_NurseId");

            migrationBuilder.RenameIndex(
                name: "IX_HospitalEmployees_hospitalDepartmentId",
                table: "Nurses",
                newName: "IX_Nurses_hospitalDepartmentId");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "Nurses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nurses",
                table: "Nurses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalTitle = table.Column<int>(type: "int", nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientSurgeryId = table.Column<int>(type: "int", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    FirstLanguageID = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    InServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OutServiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    hospitalDepartmentId = table.Column<int>(type: "int", nullable: true),
                    Salery = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_HospitalDepartments_hospitalDepartmentId",
                        column: x => x.hospitalDepartmentId,
                        principalTable: "HospitalDepartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctors_PatientSurgeries_PatientSurgeryId",
                        column: x => x.PatientSurgeryId,
                        principalTable: "PatientSurgeries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DoctorId",
                table: "Addresses",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_hospitalDepartmentId",
                table: "Doctors",
                column: "hospitalDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PatientSurgeryId",
                table: "Doctors",
                column: "PatientSurgeryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Doctors_DoctorId",
                table: "Addresses",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Nurses_NurseId",
                table: "Addresses",
                column: "NurseId",
                principalTable: "Nurses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAppointments_Doctors_DoctorId",
                table: "DoctorAppointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_HospitalDepartments_hospitalDepartmentId",
                table: "Nurses",
                column: "hospitalDepartmentId",
                principalTable: "HospitalDepartments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Doctors_DoctorId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Nurses_NurseId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAppointments_Doctors_DoctorId",
                table: "DoctorAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_HospitalDepartments_hospitalDepartmentId",
                table: "Nurses");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_DoctorId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nurses",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Nurses",
                newName: "HospitalEmployees");

            migrationBuilder.RenameColumn(
                name: "NurseId",
                table: "Addresses",
                newName: "HospitalEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_NurseId",
                table: "Addresses",
                newName: "IX_Addresses_HospitalEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Nurses_hospitalDepartmentId",
                table: "HospitalEmployees",
                newName: "IX_HospitalEmployees_hospitalDepartmentId");

            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "HospitalEmployees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "HospitalEmployees",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LicenseNumber",
                table: "HospitalEmployees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LicenseValidUntil",
                table: "HospitalEmployees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicalTitle",
                table: "HospitalEmployees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientSurgeryId",
                table: "HospitalEmployees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "HospitalEmployees",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalEmployees",
                table: "HospitalEmployees",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalEmployees_PatientSurgeryId",
                table: "HospitalEmployees",
                column: "PatientSurgeryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_HospitalEmployees_HospitalEmployeeId",
                table: "Addresses",
                column: "HospitalEmployeeId",
                principalTable: "HospitalEmployees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAppointments_HospitalEmployees_DoctorId",
                table: "DoctorAppointments",
                column: "DoctorId",
                principalTable: "HospitalEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalEmployees_HospitalDepartments_hospitalDepartmentId",
                table: "HospitalEmployees",
                column: "hospitalDepartmentId",
                principalTable: "HospitalDepartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalEmployees_PatientSurgeries_PatientSurgeryId",
                table: "HospitalEmployees",
                column: "PatientSurgeryId",
                principalTable: "PatientSurgeries",
                principalColumn: "Id");
        }
    }
}
