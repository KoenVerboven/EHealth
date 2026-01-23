using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKmfSoft_EHealth_API.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetweenHospitalRoomAndMoreSpecificRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InUseByPatientId",
                table: "IntensiveCareRooms",
                newName: "PatientId");

            migrationBuilder.AddColumn<int>(
                name: "MorePersonPatientRoomId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "OnePersonPatientRooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "OnePersonPatientRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "MorePersonPatientRooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "IntensiveCareRooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MorePersonPatientRoomId",
                table: "Patients",
                column: "MorePersonPatientRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_OnePersonPatientRooms_HospitalId",
                table: "OnePersonPatientRooms",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_MorePersonPatientRooms_HospitalId",
                table: "MorePersonPatientRooms",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_IntensiveCareRooms_HospitalId",
                table: "IntensiveCareRooms",
                column: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_IntensiveCareRooms_Hospitals_HospitalId",
                table: "IntensiveCareRooms",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MorePersonPatientRooms_Hospitals_HospitalId",
                table: "MorePersonPatientRooms",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OnePersonPatientRooms_Hospitals_HospitalId",
                table: "OnePersonPatientRooms",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_MorePersonPatientRooms_MorePersonPatientRoomId",
                table: "Patients",
                column: "MorePersonPatientRoomId",
                principalTable: "MorePersonPatientRooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntensiveCareRooms_Hospitals_HospitalId",
                table: "IntensiveCareRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_MorePersonPatientRooms_Hospitals_HospitalId",
                table: "MorePersonPatientRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_OnePersonPatientRooms_Hospitals_HospitalId",
                table: "OnePersonPatientRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_MorePersonPatientRooms_MorePersonPatientRoomId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MorePersonPatientRoomId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_OnePersonPatientRooms_HospitalId",
                table: "OnePersonPatientRooms");

            migrationBuilder.DropIndex(
                name: "IX_MorePersonPatientRooms_HospitalId",
                table: "MorePersonPatientRooms");

            migrationBuilder.DropIndex(
                name: "IX_IntensiveCareRooms_HospitalId",
                table: "IntensiveCareRooms");

            migrationBuilder.DropColumn(
                name: "MorePersonPatientRoomId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "OnePersonPatientRooms");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "OnePersonPatientRooms");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "MorePersonPatientRooms");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "IntensiveCareRooms");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "IntensiveCareRooms",
                newName: "InUseByPatientId");
        }
    }
}
