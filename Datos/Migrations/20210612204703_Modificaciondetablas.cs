using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Datos.Migrations
{
    public partial class Modificaciondetablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscritos_Cursos_CodigoCurso",
                table: "Inscritos");

            migrationBuilder.DropIndex(
                name: "IX_Inscritos_CodigoCurso",
                table: "Inscritos");

            migrationBuilder.DropColumn(
                name: "CodigoCurso",
                table: "Inscritos");

            migrationBuilder.CreateTable(
                name: "CursoInscrito",
                columns: table => new
                {
                    CodigoCursoInscrito = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CodigoCurso = table.Column<int>(nullable: false),
                    Identificacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoInscrito", x => x.CodigoCursoInscrito);
                    table.ForeignKey(
                        name: "FK_CursoInscrito_Cursos_CodigoCurso",
                        column: x => x.CodigoCurso,
                        principalTable: "Cursos",
                        principalColumn: "CodigoCurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoInscrito_Inscritos_Identificacion",
                        column: x => x.Identificacion,
                        principalTable: "Inscritos",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoInscrito_CodigoCurso",
                table: "CursoInscrito",
                column: "CodigoCurso");

            migrationBuilder.CreateIndex(
                name: "IX_CursoInscrito_Identificacion",
                table: "CursoInscrito",
                column: "Identificacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoInscrito");

            migrationBuilder.AddColumn<int>(
                name: "CodigoCurso",
                table: "Inscritos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inscritos_CodigoCurso",
                table: "Inscritos",
                column: "CodigoCurso");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscritos_Cursos_CodigoCurso",
                table: "Inscritos",
                column: "CodigoCurso",
                principalTable: "Cursos",
                principalColumn: "CodigoCurso",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
