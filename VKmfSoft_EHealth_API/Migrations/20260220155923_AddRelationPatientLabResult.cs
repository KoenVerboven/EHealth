using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKmfSoft_EHealth_API.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationPatientLabResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PatientLabResults_PatientMedicalRecordId",
                table: "PatientLabResults",
                column: "PatientMedicalRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientLabResults_PatientMedicalRecords_PatientMedicalRecordId",
                table: "PatientLabResults",
                column: "PatientMedicalRecordId",
                principalTable: "PatientMedicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientLabResults_PatientMedicalRecords_PatientMedicalRecordId",
                table: "PatientLabResults");

            migrationBuilder.DropIndex(
                name: "IX_PatientLabResults_PatientMedicalRecordId",
                table: "PatientLabResults");
        }
    }
}
