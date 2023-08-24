using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InteractHealthProDatabase.Data.Migrations
{
    /// <inheritdoc />
    public partial class MedHistoryAccident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "MedicalHistoryPostAccident",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    TreatmentCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Appointment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Doctor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistoryPostAccident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistoryPostAccident_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistoryAccident_MedicalHistoryPostAccidentId",
                table: "MedicalHistoryAccident",
                column: "MedicalHistoryPostAccidentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistoryAccident_MedicalHistoryPreAccidentId",
                table: "MedicalHistoryAccident",
                column: "MedicalHistoryPreAccidentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistoryPostAccident_ClientId",
                table: "MedicalHistoryPostAccident",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistoryAccident_MedicalHistoryPostAccident_MedicalHistoryPostAccidentId",
                table: "MedicalHistoryAccident",
                column: "MedicalHistoryPostAccidentId",
                principalTable: "MedicalHistoryPostAccident",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistoryAccident_MedicalHistoryPreAccident_MedicalHistoryPreAccidentId",
                table: "MedicalHistoryAccident",
                column: "MedicalHistoryPreAccidentId",
                principalTable: "MedicalHistoryPreAccident",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistoryAccident_MedicalHistoryPostAccident_MedicalHistoryPostAccidentId",
                table: "MedicalHistoryAccident");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistoryAccident_MedicalHistoryPreAccident_MedicalHistoryPreAccidentId",
                table: "MedicalHistoryAccident");

            migrationBuilder.DropTable(
                name: "MedicalHistoryPostAccident");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistoryAccident_MedicalHistoryPostAccidentId",
                table: "MedicalHistoryAccident");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistoryAccident_MedicalHistoryPreAccidentId",
                table: "MedicalHistoryAccident");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryPostAccidentId",
                table: "MedicalHistoryAccident");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryPreAccidentId",
                table: "MedicalHistoryAccident");
        }
    }
}
