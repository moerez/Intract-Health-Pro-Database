using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InteractHealthProDatabase.Data.Migrations
{
    /// <inheritdoc />
    public partial class Psychotherapy4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Psychotherapies");

            migrationBuilder.DropColumn(
                name: "CellPhone",
                table: "Psychotherapies");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Psychotherapies");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Psychotherapies");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Psychotherapies");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Psychotherapies");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Psychotherapies");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Psychotherapies");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Psychotherapies");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Psychotherapies");

           /* migrationBuilder.DropSequence(
                name: "PsychotherapySequence");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Psychotherapies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR [PsychotherapySequence]")
                .Annotation("SqlServer:Identity", "1, 1");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.CreateSequence(
                name: "PsychotherapySequence");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Psychotherapies",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [PsychotherapySequence]",
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");*/

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Psychotherapies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CellPhone",
                table: "Psychotherapies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Psychotherapies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Psychotherapies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Psychotherapies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Psychotherapies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Psychotherapies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Psychotherapies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Psychotherapies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Psychotherapies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
