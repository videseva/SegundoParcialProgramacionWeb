﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(ParcialDbContext))]
    [Migration("20210612190703_PrimeraMigracion")]
    partial class PrimeraMigracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entidad.Curso", b =>
                {
                    b.Property<int>("CodigoCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CuposDisponibles")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("CodigoCurso");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Entidad.Inscrito", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("CodigoCurso")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<string>("TipoIdentificacion")
                        .HasColumnType("text");

                    b.HasKey("Identificacion");

                    b.HasIndex("CodigoCurso");

                    b.ToTable("Inscritos");
                });

            modelBuilder.Entity("Entidad.Inscrito", b =>
                {
                    b.HasOne("Entidad.Curso", "Curso")
                        .WithMany("Inscritos")
                        .HasForeignKey("CodigoCurso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
