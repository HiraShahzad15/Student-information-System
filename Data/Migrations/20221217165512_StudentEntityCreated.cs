using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_information.Data.Migrations
{
    public partial class StudentEntityCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    FeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.FeeId);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<int>(type: "int", nullable: false),
                    SubId = table.Column<int>(type: "int", nullable: false),
                    SubjectsSubId = table.Column<int>(type: "int", nullable: true),
                    FeeId = table.Column<int>(type: "int", nullable: false),
                    FeesFeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StdId);
                    table.ForeignKey(
                        name: "FK_Student_Fees_FeesFeeId",
                        column: x => x.FeesFeeId,
                        principalTable: "Fees",
                        principalColumn: "FeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Subject_SubjectsSubId",
                        column: x => x.SubjectsSubId,
                        principalTable: "Subject",
                        principalColumn: "SubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StdSubject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StdId = table.Column<int>(type: "int", nullable: false),
                    StudentsStdId = table.Column<int>(type: "int", nullable: true),
                    SubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StdSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StdSubject_Student_StudentsStdId",
                        column: x => x.StudentsStdId,
                        principalTable: "Student",
                        principalColumn: "StdId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StdSubject_Subject_SubId",
                        column: x => x.SubId,
                        principalTable: "Subject",
                        principalColumn: "SubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StdSubject_StudentsStdId",
                table: "StdSubject",
                column: "StudentsStdId");

            migrationBuilder.CreateIndex(
                name: "IX_StdSubject_SubId",
                table: "StdSubject",
                column: "SubId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_FeesFeeId",
                table: "Student",
                column: "FeesFeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SubjectsSubId",
                table: "Student",
                column: "SubjectsSubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StdSubject");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
