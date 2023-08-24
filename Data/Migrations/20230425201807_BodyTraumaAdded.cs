using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InteractHealthProDatabase.Data.Migrations
{
    /// <inheritdoc />
    public partial class BodyTraumaAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicalHistoryPostAccidentId",
                table: "Medication",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medication_MedicalHistoryPostAccidentId",
                table: "Medication",
                column: "MedicalHistoryPostAccidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_MedicalHistoryPostAccident_1_MedicalHistoryPostAccidentId",
                table: "Medication",
                column: "MedicalHistoryPostAccidentId",
                principalTable: "MedicalHistoryPostAccident_1",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medication_MedicalHistoryPostAccident_1_MedicalHistoryPostAccidentId",
                table: "Medication");

            migrationBuilder.DropIndex(
                name: "IX_Medication_MedicalHistoryPostAccidentId",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryPostAccidentId",
                table: "Medication");
        }
    }
}
