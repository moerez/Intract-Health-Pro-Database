using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InteractHealthProDatabase.Data.Migrations
{
    /// <inheritdoc />
    public partial class MedicationHistoryPreAccident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medication_MedicalHistory_MedicalHistoryId",
                table: "Medication");

            migrationBuilder.DropTable(
                name: "MedicalHistory");

            migrationBuilder.DropSequence(
                name: "MedicalHistorySequence");

            migrationBuilder.RenameColumn(
                name: "MedicalHistoryId",
                table: "Medication",
                newName: "MedicalHistoryPreAccidentId");

            migrationBuilder.RenameIndex(
                name: "IX_Medication_MedicalHistoryId",
                table: "Medication",
                newName: "IX_Medication_MedicalHistoryPreAccidentId");

            migrationBuilder.CreateSequence(
                name: "MedicalHistoryPreAccidentSequence");

            migrationBuilder.CreateTable(
                name: "MedicalHistoryPreAccident",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [MedicalHistoryPreAccidentSequence]"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Hospitalized = table.Column<bool>(type: "bit", nullable: false),
                    HospitalizedCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Asthma = table.Column<bool>(type: "bit", nullable: false),
                    Arthritis = table.Column<bool>(type: "bit", nullable: false),
                    Diabetes = table.Column<bool>(type: "bit", nullable: false),
                    HeartStroke = table.Column<bool>(type: "bit", nullable: false),
                    Thyroid = table.Column<bool>(type: "bit", nullable: false),
                    Other = table.Column<bool>(type: "bit", nullable: false),
                    Cancer = table.Column<bool>(type: "bit", nullable: false),
                    None = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistoryPreAccident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistoryPreAccident_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistoryPreAccident_ClientId",
                table: "MedicalHistoryPreAccident",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_MedicalHistoryPreAccident_MedicalHistoryPreAccidentId",
                table: "Medication",
                column: "MedicalHistoryPreAccidentId",
                principalTable: "MedicalHistoryPreAccident",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medication_MedicalHistoryPreAccident_MedicalHistoryPreAccidentId",
                table: "Medication");

            migrationBuilder.DropTable(
                name: "MedicalHistoryPreAccident");

            migrationBuilder.DropSequence(
                name: "MedicalHistoryPreAccidentSequence");

            migrationBuilder.RenameColumn(
                name: "MedicalHistoryPreAccidentId",
                table: "Medication",
                newName: "MedicalHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Medication_MedicalHistoryPreAccidentId",
                table: "Medication",
                newName: "IX_Medication_MedicalHistoryId");

            migrationBuilder.CreateSequence(
                name: "MedicalHistorySequence");

            migrationBuilder.CreateTable(
                name: "MedicalHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [MedicalHistorySequence]"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Arthritis = table.Column<bool>(type: "bit", nullable: false),
                    Asthma = table.Column<bool>(type: "bit", nullable: false),
                    Cancer = table.Column<bool>(type: "bit", nullable: false),
                    Diabetes = table.Column<bool>(type: "bit", nullable: false),
                    HeartStroke = table.Column<bool>(type: "bit", nullable: false),
                    Hospitalized = table.Column<bool>(type: "bit", nullable: false),
                    HospitalizedCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    None = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Other = table.Column<bool>(type: "bit", nullable: false),
                    Thyroid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistory_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_ClientId",
                table: "MedicalHistory",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_MedicalHistory_MedicalHistoryId",
                table: "Medication",
                column: "MedicalHistoryId",
                principalTable: "MedicalHistory",
                principalColumn: "Id");
        }
    }
}
