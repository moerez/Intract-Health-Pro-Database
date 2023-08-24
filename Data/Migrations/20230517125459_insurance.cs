using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InteractHealthProDatabase.Data.Migrations
{
    /// <inheritdoc />
    public partial class insurance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistoryAccident_MedicalHistoryPostAccident_1_MedicalHistoryPostAccidentId",
                table: "MedicalHistoryAccident");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistoryAccident_MedicalHistoryPreAccident_MedicalHistoryPreAccidentId",
                table: "MedicalHistoryAccident");

            migrationBuilder.DropForeignKey(
                name: "FK_Medication_MedicalHistoryPostAccident_1_MedicalHistoryPostAccidentId",
                table: "Medication");

            migrationBuilder.DropIndex(
                name: "IX_Medication_MedicalHistoryPostAccidentId",
                table: "Medication");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistoryAccident_MedicalHistoryPostAccidentId",
                table: "MedicalHistoryAccident");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistoryAccident_MedicalHistoryPreAccidentId",
                table: "MedicalHistoryAccident");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryPostAccidentId",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryPostAccidentId",
                table: "MedicalHistoryAccident");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryPreAccidentId",
                table: "MedicalHistoryAccident");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "InsuranceCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "InsuranceCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "InsuranceCompanies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "InsuranceCompanies");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "InsuranceCompanies");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "InsuranceCompanies");

            migrationBuilder.AddColumn<int>(
                name: "MedicalHistoryPostAccidentId",
                table: "Medication",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicalHistoryPostAccidentId",
                table: "MedicalHistoryAccident",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicalHistoryPreAccidentId",
                table: "MedicalHistoryAccident",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medication_MedicalHistoryPostAccidentId",
                table: "Medication",
                column: "MedicalHistoryPostAccidentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistoryAccident_MedicalHistoryPostAccidentId",
                table: "MedicalHistoryAccident",
                column: "MedicalHistoryPostAccidentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistoryAccident_MedicalHistoryPreAccidentId",
                table: "MedicalHistoryAccident",
                column: "MedicalHistoryPreAccidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistoryAccident_MedicalHistoryPostAccident_1_MedicalHistoryPostAccidentId",
                table: "MedicalHistoryAccident",
                column: "MedicalHistoryPostAccidentId",
                principalTable: "MedicalHistoryPostAccident_1",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistoryAccident_MedicalHistoryPreAccident_MedicalHistoryPreAccidentId",
                table: "MedicalHistoryAccident",
                column: "MedicalHistoryPreAccidentId",
                principalTable: "MedicalHistoryPreAccident",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_MedicalHistoryPostAccident_1_MedicalHistoryPostAccidentId",
                table: "Medication",
                column: "MedicalHistoryPostAccidentId",
                principalTable: "MedicalHistoryPostAccident_1",
                principalColumn: "Id");
        }
    }
}
