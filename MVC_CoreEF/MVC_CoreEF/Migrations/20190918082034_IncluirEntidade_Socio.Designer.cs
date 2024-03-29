﻿// <auto-generated />
using System;
using MVC_CoreEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVC_CoreEF.Migrations
{
    [DbContext(typeof(AlunoContext))]
    [Migration("20190918082034_IncluirEntidade_Socio")]
    partial class IncluirEntidade_Socio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVC_CoreEF.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("TipoSocioId");

                    b.HasKey("Id");

                    b.HasIndex("TipoSocioId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("MVC_CoreEF.Models.Socio", b =>
                {
                    b.Property<int>("TipoSocioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Duracao");

                    b.Property<int>("TaxaDesconto");

                    b.HasKey("TipoSocioId");

                    b.ToTable("Socio");
                });

            modelBuilder.Entity("MVC_CoreEF.Models.Aluno", b =>
                {
                    b.HasOne("MVC_CoreEF.Models.Socio", "TipoSocio")
                        .WithMany()
                        .HasForeignKey("TipoSocioId");
                });
#pragma warning restore 612, 618
        }
    }
}
