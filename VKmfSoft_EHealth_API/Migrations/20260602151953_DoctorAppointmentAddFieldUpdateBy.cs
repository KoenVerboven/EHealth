using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKmfSoft_EHealth_API.Migrations
{
    /// <inheritdoc />
    public partial class DoctorAppointmentAddFieldUpdateBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "DoctorAppointments",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "DoctorAppointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Updatedby",
                table: "DoctorAppointments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "DoctorAppointments");

            migrationBuilder.DropColumn(
                name: "Updatedby",
                table: "DoctorAppointments");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "DoctorAppointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }
    }
}
