using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTask.Migrations
{
    /// <inheritdoc />
    public partial class fileTablesDeleteFKUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputFiles_Users_UserId",
                table: "InputFiles");

            migrationBuilder.DropIndex(
                name: "IX_InputFiles_UserId",
                table: "InputFiles");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "InputFiles",
                newName: "StartName");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "InputFiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalName",
                table: "InputFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalName",
                table: "InputFiles");

            migrationBuilder.RenameColumn(
                name: "StartName",
                table: "InputFiles",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "InputFiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_InputFiles_UserId",
                table: "InputFiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InputFiles_Users_UserId",
                table: "InputFiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
