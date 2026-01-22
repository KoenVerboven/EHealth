using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKmfSoft_EHealth_API.Migrations
{
    /// <inheritdoc />
    public partial class AddReletionshipBetweenPatientDoctorAppointmentDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MedicalWorkerId",
                table: "DoctorAppointments",
                newName: "DoctorId");

            migrationBuilder.CreateTable(
                name: "IntensiveCareRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InUseByPatientId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntensiveCareRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MorePersonPatientRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayPricePerPerson = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberOfBeds = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MorePersonPatientRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnePersonPatientRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnePersonPatientRooms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAppointments_DoctorId",
                table: "DoctorAppointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAppointments_PatientId",
                table: "DoctorAppointments",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAppointments_Doctors_DoctorId",
                table: "DoctorAppointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAppointments_Patients_PatientId",
                table: "DoctorAppointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAppointments_Doctors_DoctorId",
                table: "DoctorAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAppointments_Patients_PatientId",
                table: "DoctorAppointments");

            migrationBuilder.DropTable(
                name: "IntensiveCareRooms");

            migrationBuilder.DropTable(
                name: "MorePersonPatientRooms");

            migrationBuilder.DropTable(
                name: "OnePersonPatientRooms");

            migrationBuilder.DropIndex(
                name: "IX_DoctorAppointments_DoctorId",
                table: "DoctorAppointments");

            migrationBuilder.DropIndex(
                name: "IX_DoctorAppointments_PatientId",
                table: "DoctorAppointments");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "DoctorAppointments",
                newName: "MedicalWorkerId");
        }
    }
}
