using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InteractHealthProDatabase.Data.Migrations
{
    /// <inheritdoc />
    public partial class BodyParts3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyPart_AccidentDetails_AccidentDetailId",
                table: "BodyPart");

            migrationBuilder.RenameColumn(
                name: "AccidentDetailId",
                table: "BodyPart",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_BodyPart_AccidentDetailId",
                table: "BodyPart",
                newName: "IX_BodyPart_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyPart_Clients_ClientId",
                table: "BodyPart",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyPart_Clients_ClientId",
                table: "BodyPart");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "BodyPart",
                newName: "AccidentDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_BodyPart_ClientId",
                table: "BodyPart",
                newName: "IX_BodyPart_AccidentDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyPart_AccidentDetails_AccidentDetailId",
                table: "BodyPart",
                column: "AccidentDetailId",
                principalTable: "AccidentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
