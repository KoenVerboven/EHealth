using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKmfSoft_EHealth_API.Migrations
{
    /// <inheritdoc />
    public partial class AddEmergencyToom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmergencyRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyRoomOccupations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    EmergencyRoomId = table.Column<int>(type: "int", nullable: false),
                    EmergencyGrade = table.Column<byte>(type: "tinyint", nullable: false),
                    PatientIsCheckedByDoctor = table.Column<bool>(type: "bit", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyRoomOccupations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyRoomOccupations_EmergencyRooms_EmergencyRoomId",
                        column: x => x.EmergencyRoomId,
                        principalTable: "EmergencyRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyRoomOccupations_EmergencyRoomId",
                table: "EmergencyRoomOccupations",
                column: "EmergencyRoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmergencyRoomOccupations");

            migrationBuilder.DropTable(
                name: "EmergencyRooms");
        }
    }
}
