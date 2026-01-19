using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKmfSoft_EHealth_API.Migrations
{
    /// <inheritdoc />
    public partial class AddEntitiesDoctorAndNurse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalWorkers");

            migrationBuilder.DropTable(
                name: "PatientVitalSigns");

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
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    OutServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        name: "FK_Doctors_PatientSurgery_PatientSurgeryId",
                        column: x => x.PatientSurgeryId,
                        principalTable: "PatientSurgery",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    OutServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hospitalDepartmentId = table.Column<int>(type: "int", nullable: true),
                    Salery = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurses_HospitalDepartments_hospitalDepartmentId",
                        column: x => x.hospitalDepartmentId,
                        principalTable: "HospitalDepartments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_hospitalDepartmentId",
                table: "Doctors",
                column: "hospitalDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PatientSurgeryId",
                table: "Doctors",
                column: "PatientSurgeryId");

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_hospitalDepartmentId",
                table: "Nurses",
                column: "hospitalDepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Nurses");

            migrationBuilder.CreateTable(
                name: "MedicalWorkers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    FirstLanguageID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    InServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicalTitle = table.Column<int>(type: "int", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    OutServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientSurgeryId = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salery = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SpecializationId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalWorkers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalWorkers_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalWorkers_PatientSurgery_PatientSurgeryId",
                        column: x => x.PatientSurgeryId,
                        principalTable: "PatientSurgery",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientVitalSigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodPressureDiastolic = table.Column<int>(type: "int", nullable: false),
                    BloodPressureSystolic = table.Column<int>(type: "int", nullable: false),
                    HeartRate = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OxygenSaturation = table.Column<float>(type: "real", nullable: false),
                    Pain = table.Column<int>(type: "int", nullable: false),
                    PatientDiagnoseId = table.Column<int>(type: "int", nullable: false),
                    PatientHealthHistoryId = table.Column<int>(type: "int", nullable: true),
                    PatientMedicalHistoryId = table.Column<int>(type: "int", nullable: false),
                    RecordedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RespiratoryRate = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientVitalSigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientVitalSigns_PatientHealthHistory_PatientHealthHistoryId",
                        column: x => x.PatientHealthHistoryId,
                        principalTable: "PatientHealthHistory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalWorkers_HospitalId",
                table: "MedicalWorkers",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalWorkers_PatientSurgeryId",
                table: "MedicalWorkers",
                column: "PatientSurgeryId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVitalSigns_PatientHealthHistoryId",
                table: "PatientVitalSigns",
                column: "PatientHealthHistoryId");
        }
    }
}
