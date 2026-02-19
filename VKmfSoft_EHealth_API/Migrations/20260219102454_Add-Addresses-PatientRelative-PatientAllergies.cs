using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKmfSoft_EHealth_API.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressesPatientRelativePatientAllergies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MorePersonPatientRoomOccupation_MorePersonPatientRooms_MorePersonPatientRoomId",
                table: "MorePersonPatientRoomOccupation");

            migrationBuilder.DropForeignKey(
                name: "FK_OnePersonPatientRoomOccupation_OnePersonPatientRooms_OnePersonPatientRoomId",
                table: "OnePersonPatientRoomOccupation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OnePersonPatientRoomOccupation",
                table: "OnePersonPatientRoomOccupation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MorePersonPatientRoomOccupation",
                table: "MorePersonPatientRoomOccupation");

            migrationBuilder.RenameTable(
                name: "OnePersonPatientRoomOccupation",
                newName: "OnePersonPatientRoomOccupations");

            migrationBuilder.RenameTable(
                name: "MorePersonPatientRoomOccupation",
                newName: "MorePersonPatientRoomOccupations");

            migrationBuilder.RenameIndex(
                name: "IX_OnePersonPatientRoomOccupation_OnePersonPatientRoomId",
                table: "OnePersonPatientRoomOccupations",
                newName: "IX_OnePersonPatientRoomOccupations_OnePersonPatientRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_MorePersonPatientRoomOccupation_MorePersonPatientRoomId",
                table: "MorePersonPatientRoomOccupations",
                newName: "IX_MorePersonPatientRoomOccupations_MorePersonPatientRoomId");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "EmergencyRooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancellingReason",
                table: "DoctorAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OnePersonPatientRoomOccupations",
                table: "OnePersonPatientRoomOccupations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MorePersonPatientRoomOccupations",
                table: "MorePersonPatientRoomOccupations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAndNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    LandCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientAllergies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAllergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientPainRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PainRegistrationNumber = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientPainRegistrations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientRelatives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationType = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
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
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRelatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientRelatives_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyRooms_HospitalId",
                table: "EmergencyRooms",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRelatives_PatientId",
                table: "PatientRelatives",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyRooms_Hospitals_HospitalId",
                table: "EmergencyRooms",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MorePersonPatientRoomOccupations_MorePersonPatientRooms_MorePersonPatientRoomId",
                table: "MorePersonPatientRoomOccupations",
                column: "MorePersonPatientRoomId",
                principalTable: "MorePersonPatientRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnePersonPatientRoomOccupations_OnePersonPatientRooms_OnePersonPatientRoomId",
                table: "OnePersonPatientRoomOccupations",
                column: "OnePersonPatientRoomId",
                principalTable: "OnePersonPatientRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyRooms_Hospitals_HospitalId",
                table: "EmergencyRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_MorePersonPatientRoomOccupations_MorePersonPatientRooms_MorePersonPatientRoomId",
                table: "MorePersonPatientRoomOccupations");

            migrationBuilder.DropForeignKey(
                name: "FK_OnePersonPatientRoomOccupations_OnePersonPatientRooms_OnePersonPatientRoomId",
                table: "OnePersonPatientRoomOccupations");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "PatientAllergies");

            migrationBuilder.DropTable(
                name: "PatientPainRegistrations");

            migrationBuilder.DropTable(
                name: "PatientRelatives");

            migrationBuilder.DropIndex(
                name: "IX_EmergencyRooms_HospitalId",
                table: "EmergencyRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OnePersonPatientRoomOccupations",
                table: "OnePersonPatientRoomOccupations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MorePersonPatientRoomOccupations",
                table: "MorePersonPatientRoomOccupations");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "EmergencyRooms");

            migrationBuilder.DropColumn(
                name: "CancellingReason",
                table: "DoctorAppointments");

            migrationBuilder.RenameTable(
                name: "OnePersonPatientRoomOccupations",
                newName: "OnePersonPatientRoomOccupation");

            migrationBuilder.RenameTable(
                name: "MorePersonPatientRoomOccupations",
                newName: "MorePersonPatientRoomOccupation");

            migrationBuilder.RenameIndex(
                name: "IX_OnePersonPatientRoomOccupations_OnePersonPatientRoomId",
                table: "OnePersonPatientRoomOccupation",
                newName: "IX_OnePersonPatientRoomOccupation_OnePersonPatientRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_MorePersonPatientRoomOccupations_MorePersonPatientRoomId",
                table: "MorePersonPatientRoomOccupation",
                newName: "IX_MorePersonPatientRoomOccupation_MorePersonPatientRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OnePersonPatientRoomOccupation",
                table: "OnePersonPatientRoomOccupation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MorePersonPatientRoomOccupation",
                table: "MorePersonPatientRoomOccupation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MorePersonPatientRoomOccupation_MorePersonPatientRooms_MorePersonPatientRoomId",
                table: "MorePersonPatientRoomOccupation",
                column: "MorePersonPatientRoomId",
                principalTable: "MorePersonPatientRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnePersonPatientRoomOccupation_OnePersonPatientRooms_OnePersonPatientRoomId",
                table: "OnePersonPatientRoomOccupation",
                column: "OnePersonPatientRoomId",
                principalTable: "OnePersonPatientRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
