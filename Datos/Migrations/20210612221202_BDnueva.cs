using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Datos.Migrations
{
    public partial class BDnueva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CodigoCurso = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    CuposDisponibles = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CodigoCurso);
                });

            migrationBuilder.CreateTable(
                name: "Inscritos",
                columns: table => new
                {
                    Identificacion = table.Column<string>(nullable: false),
                    TipoIdentificacion = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscritos", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "CursoInscritos",
                columns: table => new
                {
                    IdCursoInscrito = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CodigoCurso = table.Column<int>(nullable: false),
                    Identificacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoInscritos", x => x.IdCursoInscrito);
                    table.ForeignKey(
                        name: "FK_CursoInscritos_Cursos_CodigoCurso",
                        column: x => x.CodigoCurso,
                        principalTable: "Cursos",
                        principalColumn: "CodigoCurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoInscritos_Inscritos_Identificacion",
                        column: x => x.Identificacion,
                        principalTable: "Inscritos",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoInscritos_CodigoCurso",
                table: "CursoInscritos",
                column: "CodigoCurso");

            migrationBuilder.CreateIndex(
                name: "IX_CursoInscritos_Identificacion",
                table: "CursoInscritos",
                column: "Identificacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoInscritos");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Inscritos");
        }
    }
}
