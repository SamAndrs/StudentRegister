using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentRegister.Migrations
{
    /// <inheritdoc />
    public partial class classRepo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentClass_StudentClassId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass");

            migrationBuilder.RenameTable(
                name: "StudentClass",
                newName: "StudentClasses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClasses",
                table: "StudentClasses",
                column: "StudentClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentClasses_StudentClassId",
                table: "Students",
                column: "StudentClassId",
                principalTable: "StudentClasses",
                principalColumn: "StudentClassId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentClasses_StudentClassId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClasses",
                table: "StudentClasses");

            migrationBuilder.RenameTable(
                name: "StudentClasses",
                newName: "StudentClass");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass",
                column: "StudentClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentClass_StudentClassId",
                table: "Students",
                column: "StudentClassId",
                principalTable: "StudentClass",
                principalColumn: "StudentClassId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
