using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWebApi.Migrations
{
    public partial class newsubjtallocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllocateClassroomModel",
                columns: table => new
                {
                    AllocateClassroomID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherID = table.Column<int>(nullable: false),
                    ClassroomID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocateClassroomModel", x => x.AllocateClassroomID);
                    table.ForeignKey(
                        name: "FK_AllocateClassroomModel_Classrooms_ClassroomID",
                        column: x => x.ClassroomID,
                        principalTable: "Classrooms",
                        principalColumn: "ClassroomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllocateClassroomModel_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllocateSubjects",
                columns: table => new
                {
                    AllocateSubjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocateSubjects", x => x.AllocateSubjectID);
                    table.ForeignKey(
                        name: "FK_AllocateSubjects_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllocateSubjects_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllocateClassroomModel_ClassroomID",
                table: "AllocateClassroomModel",
                column: "ClassroomID");

            migrationBuilder.CreateIndex(
                name: "IX_AllocateClassroomModel_TeacherID",
                table: "AllocateClassroomModel",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_AllocateSubjects_SubjectID",
                table: "AllocateSubjects",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AllocateSubjects_TeacherID",
                table: "AllocateSubjects",
                column: "TeacherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllocateClassroomModel");

            migrationBuilder.DropTable(
                name: "AllocateSubjects");
        }
    }
}
