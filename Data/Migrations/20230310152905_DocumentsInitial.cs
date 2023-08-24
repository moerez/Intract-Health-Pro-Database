using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InteractHealthProDatabase.Data.Migrations
{
    /// <inheritdoc />
    public partial class DocumentsInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "DocumentsSequence");

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [DocumentsSequence]"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DocumentStr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [DocumentsSequence]"),
                    GeneralTreatmentPlan = table.Column<bool>(type: "bit", nullable: false),
                    Ocf18TpReceived = table.Column<bool>(type: "bit", nullable: false),
                    Ocf23MigReceived = table.Column<bool>(type: "bit", nullable: false),
                    DateDeliveredByIhp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryMethod = table.Column<int>(type: "int", nullable: false),
                    DeliveryMethodNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfAssociate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentDeliveries_Documents_Id",
                        column: x => x.Id,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [DocumentsSequence]"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Submitted = table.Column<bool>(type: "bit", nullable: false),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentForms_Documents_Id",
                        column: x => x.Id,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentRecoveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [DocumentsSequence]"),
                    GeneralTreatmentPlan = table.Column<bool>(type: "bit", nullable: false),
                    Ocf18TpReceived = table.Column<bool>(type: "bit", nullable: false),
                    Ocf23MigReceived = table.Column<bool>(type: "bit", nullable: false),
                    DateReceivedByIhp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceivedFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryMethod = table.Column<int>(type: "int", nullable: false),
                    ReceivedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentRecoveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentRecoveries_Documents_Id",
                        column: x => x.Id,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [DocumentsSequence]"),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryMethod = table.Column<int>(type: "int", nullable: false),
                    DeliveryMethodNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfAssociate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentRequests_Documents_Id",
                        column: x => x.Id,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ClientId",
                table: "Documents",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentDeliveries");

            migrationBuilder.DropTable(
                name: "DocumentForms");

            migrationBuilder.DropTable(
                name: "DocumentRecoveries");

            migrationBuilder.DropTable(
                name: "DocumentRequests");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropSequence(
                name: "DocumentsSequence");
        }
    }
}
