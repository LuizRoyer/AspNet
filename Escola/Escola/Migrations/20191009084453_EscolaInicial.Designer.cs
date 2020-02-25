﻿// <auto-generated />
using Escolas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Escola.Migrations
{
    [DbContext(typeof(EscolaContext))]
    [Migration("20191009084453_EscolaInicial")]
    partial class EscolaInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Escolas.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Creditos");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Escolas.Models.Estudante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DataMatricula");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Estudantes");
                });

            modelBuilder.Entity("Escolas.Models.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CursoId");

                    b.Property<int>("EstudanteId");

                    b.Property<int?>("Nota");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("EstudanteId");

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("Escolas.Models.Matricula", b =>
                {
                    b.HasOne("Escolas.Models.Curso", "Curso")
                        .WithMany("ListaMatriculas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Escolas.Models.Estudante", "Estudante")
                        .WithMany("ListaMatriculas")
                        .HasForeignKey("EstudanteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}