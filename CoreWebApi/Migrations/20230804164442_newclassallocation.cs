using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWebApi.Migrations
{
    public partial class newclassallocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllocateClassroomModel_Classrooms_ClassroomID",
                table: "AllocateClassroomModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AllocateClassroomModel_Teachers_TeacherID",
                table: "AllocateClassroomModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllocateClassroomModel",
                table: "AllocateClassroomModel");

            migrationBuilder.RenameTable(
                name: "AllocateClassroomModel",
                newName: "AllocateClassrooms");

            migrationBuilder.RenameIndex(
                name: "IX_AllocateClassroomModel_TeacherID",
                table: "AllocateClassrooms",
                newName: "IX_AllocateClassrooms_TeacherID");

            migrationBuilder.RenameIndex(
                name: "IX_AllocateClassroomModel_ClassroomID",
                table: "AllocateClassrooms",
                newName: "IX_AllocateClassrooms_ClassroomID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllocateClassrooms",
                table: "AllocateClassrooms",
                column: "AllocateClassroomID");

            migrationBuilder.AddForeignKey(
                name: "FK_AllocateClassrooms_Classrooms_ClassroomID",
                table: "AllocateClassrooms",
                column: "ClassroomID",
                principalTable: "Classrooms",
                principalColumn: "ClassroomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllocateClassrooms_Teachers_TeacherID",
                table: "AllocateClassrooms",
                column: "TeacherID",
                principalTable: "Teachers",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllocateClassrooms_Classrooms_ClassroomID",
                table: "AllocateClassrooms");

            migrationBuilder.DropForeignKey(
                name: "FK_AllocateClassrooms_Teachers_TeacherID",
                table: "AllocateClassrooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllocateClassrooms",
                table: "AllocateClassrooms");

            migrationBuilder.RenameTable(
                name: "AllocateClassrooms",
                newName: "AllocateClassroomModel");

            migrationBuilder.RenameIndex(
                name: "IX_AllocateClassrooms_TeacherID",
                table: "AllocateClassroomModel",
                newName: "IX_AllocateClassroomModel_TeacherID");

            migrationBuilder.RenameIndex(
                name: "IX_AllocateClassrooms_ClassroomID",
                table: "AllocateClassroomModel",
                newName: "IX_AllocateClassroomModel_ClassroomID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllocateClassroomModel",
                table: "AllocateClassroomModel",
                column: "AllocateClassroomID");

            migrationBuilder.AddForeignKey(
                name: "FK_AllocateClassroomModel_Classrooms_ClassroomID",
                table: "AllocateClassroomModel",
                column: "ClassroomID",
                principalTable: "Classrooms",
                principalColumn: "ClassroomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllocateClassroomModel_Teachers_TeacherID",
                table: "AllocateClassroomModel",
                column: "TeacherID",
                principalTable: "Teachers",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
