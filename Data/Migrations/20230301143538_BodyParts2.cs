using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InteractHealthProDatabase.Data.Migrations
{
    /// <inheritdoc />
    public partial class BodyParts2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArmNotes",
                table: "BodyPart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneralNotes",
                table: "BodyPart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeadNotes",
                table: "BodyPart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegNotes",
                table: "BodyPart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NeckAndBackNotes",
                table: "BodyPart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherNotes",
                table: "BodyPart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TorsoNotes",
                table: "BodyPart",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArmNotes",
                table: "BodyPart");

            migrationBuilder.DropColumn(
                name: "GeneralNotes",
                table: "BodyPart");

            migrationBuilder.DropColumn(
                name: "HeadNotes",
                table: "BodyPart");

            migrationBuilder.DropColumn(
                name: "LegNotes",
                table: "BodyPart");

            migrationBuilder.DropColumn(
                name: "NeckAndBackNotes",
                table: "BodyPart");

            migrationBuilder.DropColumn(
                name: "OtherNotes",
                table: "BodyPart");

            migrationBuilder.DropColumn(
                name: "TorsoNotes",
                table: "BodyPart");
        }
    }
}
