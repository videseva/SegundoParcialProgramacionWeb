using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Datos.Migrations
{
    public partial class PrimeraMigracion : Migration
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
                    CodigoCurso = table.Column<int>(nullable: false),
                    TipoIdentificacion = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscritos", x => x.Identificacion);
                    table.ForeignKey(
                        name: "FK_Inscritos_Cursos_CodigoCurso",
                        column: x => x.CodigoCurso,
                        principalTable: "Cursos",
                        principalColumn: "CodigoCurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscritos_CodigoCurso",
                table: "Inscritos",
                column: "CodigoCurso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscritos");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
