using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InteractHealthProDatabase.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedBodyTrauma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistoryAccident_MedicalHistoryPostAccident_MedicalHistoryPostAccidentId",
                table: "MedicalHistoryAccident");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistoryPostAccident_Clients_ClientId",
                table: "MedicalHistoryPostAccident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistoryPostAccident",
                table: "MedicalHistoryPostAccident");

            migrationBuilder.RenameTable(
                name: "MedicalHistoryPostAccident",
                newName: "MedicalHistoryPostAccident_1");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistoryPostAccident_ClientId",
                table: "MedicalHistoryPostAccident_1",
                newName: "IX_MedicalHistoryPostAccident_1_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistoryPostAccident_1",
                table: "MedicalHistoryPostAccident_1",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BodyTrauma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Bruising = table.Column<bool>(type: "bit", nullable: false),
                    Bleeding = table.Column<bool>(type: "bit", nullable: false),
                    Fracture = table.Column<bool>(type: "bit", nullable: false),
                    LossOfContentiousness = table.Column<bool>(type: "bit", nullable: false),
                    HitToTheHead = table.Column<bool>(type: "bit", nullable: false),
                    None = table.Column<bool>(type: "bit", nullable: false),
                    PainRightAway = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyTrauma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BodyTrauma_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyTrauma_ClientId",
                table: "BodyTrauma",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistoryAccident_MedicalHistoryPostAccident_1_MedicalHistoryPostAccidentId",
                table: "MedicalHistoryAccident",
                column: "MedicalHistoryPostAccidentId",
                principalTable: "MedicalHistoryPostAccident_1",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistoryPostAccident_1_Clients_ClientId",
                table: "MedicalHistoryPostAccident_1",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistoryAccident_MedicalHistoryPostAccident_1_MedicalHistoryPostAccidentId",
                table: "MedicalHistoryAccident");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistoryPostAccident_1_Clients_ClientId",
                table: "MedicalHistoryPostAccident_1");

            migrationBuilder.DropTable(
                name: "BodyTrauma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistoryPostAccident_1",
                table: "MedicalHistoryPostAccident_1");

            migrationBuilder.RenameTable(
                name: "MedicalHistoryPostAccident_1",
                newName: "MedicalHistoryPostAccident");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistoryPostAccident_1_ClientId",
                table: "MedicalHistoryPostAccident",
                newName: "IX_MedicalHistoryPostAccident_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistoryPostAccident",
                table: "MedicalHistoryPostAccident",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistoryAccident_MedicalHistoryPostAccident_MedicalHistoryPostAccidentId",
                table: "MedicalHistoryAccident",
                column: "MedicalHistoryPostAccidentId",
                principalTable: "MedicalHistoryPostAccident",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistoryPostAccident_Clients_ClientId",
                table: "MedicalHistoryPostAccident",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
