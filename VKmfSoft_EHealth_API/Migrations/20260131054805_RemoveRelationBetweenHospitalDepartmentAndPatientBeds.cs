using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKmfSoft_EHealth_API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRelationBetweenHospitalDepartmentAndPatientBeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalBeds_HospitalDepartments_HospitalDepartmentId",
                table: "HospitalBeds");

            migrationBuilder.DropIndex(
                name: "IX_HospitalBeds_HospitalDepartmentId",
                table: "HospitalBeds");

            migrationBuilder.DropColumn(
                name: "HospitalDepartmentId",
                table: "HospitalBeds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HospitalDepartmentId",
                table: "HospitalBeds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HospitalBeds_HospitalDepartmentId",
                table: "HospitalBeds",
                column: "HospitalDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalBeds_HospitalDepartments_HospitalDepartmentId",
                table: "HospitalBeds",
                column: "HospitalDepartmentId",
                principalTable: "HospitalDepartments",
                principalColumn: "Id");
        }
    }
}
