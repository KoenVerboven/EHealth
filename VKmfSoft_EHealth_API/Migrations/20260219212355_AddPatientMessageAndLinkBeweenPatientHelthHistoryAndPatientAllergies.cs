using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKmfSoft_EHealth_API.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientMessageAndLinkBeweenPatientHelthHistoryAndPatientAllergies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientRelatives_Patients_PatientId",
                table: "PatientRelatives");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "PatientAllergies",
                newName: "PatientMedicalHistoryId");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "PatientRelatives",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrioritizationRelative",
                table: "PatientRelatives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientHealthHistoryId",
                table: "PatientAllergies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrioritizationAddress",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PatientMessage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageType = table.Column<byte>(type: "tinyint", nullable: false),
                    MessageWeight = table.Column<byte>(type: "tinyint", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientMessage_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergies_PatientHealthHistoryId",
                table: "PatientAllergies",
                column: "PatientHealthHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMessage_PatientId",
                table: "PatientMessage",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAllergies_PatientHealthHistory_PatientHealthHistoryId",
                table: "PatientAllergies",
                column: "PatientHealthHistoryId",
                principalTable: "PatientHealthHistory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientRelatives_Patients_PatientId",
                table: "PatientRelatives",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientAllergies_PatientHealthHistory_PatientHealthHistoryId",
                table: "PatientAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientRelatives_Patients_PatientId",
                table: "PatientRelatives");

            migrationBuilder.DropTable(
                name: "PatientMessage");

            migrationBuilder.DropIndex(
                name: "IX_PatientAllergies_PatientHealthHistoryId",
                table: "PatientAllergies");

            migrationBuilder.DropColumn(
                name: "PrioritizationRelative",
                table: "PatientRelatives");

            migrationBuilder.DropColumn(
                name: "PatientHealthHistoryId",
                table: "PatientAllergies");

            migrationBuilder.DropColumn(
                name: "PrioritizationAddress",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "PatientMedicalHistoryId",
                table: "PatientAllergies",
                newName: "PatientId");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "PatientRelatives",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientRelatives_Patients_PatientId",
                table: "PatientRelatives",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
