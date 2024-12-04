using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDoSaber.Migrations
{
    /// <inheritdoc />
    public partial class T : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_teacherId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "teacherId",
                table: "Courses",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_teacherId",
                table: "Courses",
                newName: "IX_Courses_TeacherId");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Courses",
                newName: "teacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                newName: "IX_Courses_teacherId");

            migrationBuilder.AlterColumn<int>(
                name: "teacherId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_teacherId",
                table: "Courses",
                column: "teacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
