using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDoSaber.Migrations
{
    /// <inheritdoc />
    public partial class Adicionadocpfprofessorealuno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Students");
        }
    }
}
