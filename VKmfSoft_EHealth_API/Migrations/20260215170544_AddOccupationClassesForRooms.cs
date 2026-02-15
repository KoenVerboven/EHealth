using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKmfSoft_EHealth_API.Migrations
{
    /// <inheritdoc />
    public partial class AddOccupationClassesForRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_MorePersonPatientRooms_MorePersonPatientRoomId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MorePersonPatientRoomId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MorePersonPatientRoomId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "OnePersonPatientRooms");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "IntensiveCareRooms");

            migrationBuilder.AddColumn<decimal>(
                name: "SupplementCostForOnePersonRoom",
                table: "OnePersonPatientRooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OutServiceDate",
                table: "Nurses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OutServiceDate",
                table: "Doctors",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "MorePersonPatientRoomOccupation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    MorePersonPatientRoomId = table.Column<int>(type: "int", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MorePersonPatientRoomOccupation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MorePersonPatientRoomOccupation_MorePersonPatientRooms_MorePersonPatientRoomId",
                        column: x => x.MorePersonPatientRoomId,
                        principalTable: "MorePersonPatientRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnePersonPatientRoomOccupation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    OnePersonPatientRoomId = table.Column<int>(type: "int", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientAgreeWithSupplementCost = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnePersonPatientRoomOccupation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnePersonPatientRoomOccupation_OnePersonPatientRooms_OnePersonPatientRoomId",
                        column: x => x.OnePersonPatientRoomId,
                        principalTable: "OnePersonPatientRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MorePersonPatientRoomOccupation_MorePersonPatientRoomId",
                table: "MorePersonPatientRoomOccupation",
                column: "MorePersonPatientRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_OnePersonPatientRoomOccupation_OnePersonPatientRoomId",
                table: "OnePersonPatientRoomOccupation",
                column: "OnePersonPatientRoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MorePersonPatientRoomOccupation");

            migrationBuilder.DropTable(
                name: "OnePersonPatientRoomOccupation");

            migrationBuilder.DropColumn(
                name: "SupplementCostForOnePersonRoom",
                table: "OnePersonPatientRooms");

            migrationBuilder.AddColumn<int>(
                name: "MorePersonPatientRoomId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "OnePersonPatientRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OutServiceDate",
                table: "Nurses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "IntensiveCareRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OutServiceDate",
                table: "Doctors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MorePersonPatientRoomId",
                table: "Patients",
                column: "MorePersonPatientRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_MorePersonPatientRooms_MorePersonPatientRoomId",
                table: "Patients",
                column: "MorePersonPatientRoomId",
                principalTable: "MorePersonPatientRooms",
                principalColumn: "Id");
        }
    }
}
