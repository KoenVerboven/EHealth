using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKmfSoft_EHealth_API.Migrations
{
    /// <inheritdoc />
    public partial class HospitalEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAppointments_Doctors_DoctorId",
                table: "DoctorAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_HospitalDepartments_hospitalDepartmentId",
                table: "Nurses");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nurses",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "PatientRelatives");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Nurses");

            migrationBuilder.RenameTable(
                name: "Nurses",
                newName: "HospitalEmployees");

            migrationBuilder.RenameIndex(
                name: "IX_Nurses_hospitalDepartmentId",
                table: "HospitalEmployees",
                newName: "IX_HospitalEmployees_hospitalDepartmentId");

            migrationBuilder.AddColumn<int>(
                name: "HospitalEmployeeId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientRelativeId",
                table: "Addresses",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethodId = table.Column<byte>(type: "tinyint", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetailLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetailLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetailLines_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_HospitalEmployeeId",
                table: "Addresses",
                column: "HospitalEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PatientId",
                table: "Addresses",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PatientRelativeId",
                table: "Addresses",
                column: "PatientRelativeId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalEmployees_PatientSurgeryId",
                table: "HospitalEmployees",
                column: "PatientSurgeryId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetailLines_InvoiceId",
                table: "InvoiceDetailLines",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PatientId",
                table: "Invoices",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_HospitalEmployees_HospitalEmployeeId",
                table: "Addresses",
                column: "HospitalEmployeeId",
                principalTable: "HospitalEmployees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_PatientRelatives_PatientRelativeId",
                table: "Addresses",
                column: "PatientRelativeId",
                principalTable: "PatientRelatives",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Patients_PatientId",
                table: "Addresses",
                column: "PatientId",
                principalTable: "Patients",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_HospitalEmployees_HospitalEmployeeId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_PatientRelatives_PatientRelativeId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Patients_PatientId",
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

            migrationBuilder.DropTable(
                name: "InvoiceDetailLines");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_HospitalEmployeeId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_PatientId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_PatientRelativeId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalEmployees",
                table: "HospitalEmployees");

            migrationBuilder.DropIndex(
                name: "IX_HospitalEmployees_PatientSurgeryId",
                table: "HospitalEmployees");

            migrationBuilder.DropColumn(
                name: "HospitalEmployeeId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PatientRelativeId",
                table: "Addresses");

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

            migrationBuilder.RenameIndex(
                name: "IX_HospitalEmployees_hospitalDepartmentId",
                table: "Nurses",
                newName: "IX_Nurses_hospitalDepartmentId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "PatientRelatives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "Nurses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                    hospitalDepartmentId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    FirstLanguageID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    HospitalId = table.Column<int>(type: "int", nullable: false),
                    InServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicalTitle = table.Column<int>(type: "int", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    OutServiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "IX_Doctors_hospitalDepartmentId",
                table: "Doctors",
                column: "hospitalDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PatientSurgeryId",
                table: "Doctors",
                column: "PatientSurgeryId");

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
    }
}
