﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SisEventos.Models;
using System;

namespace SisEventos.Migrations
{
    [DbContext(typeof(Banco))]
    [Migration("20181113021001_estacionamento")]
    partial class estacionamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SisEventos.Models.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CaminhoImagem");

                    b.Property<long?>("CursoId");

                    b.Property<string>("Descricao");

                    b.Property<string>("Endereco");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SisEventos.Models.Curso", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("SisEventos.Models.Estacionamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CaminhoImagem");

                    b.Property<long?>("CursoId");

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Estacionamentos");
                });

            modelBuilder.Entity("SisEventos.Models.Evento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CaminhoImagem");

                    b.Property<long?>("CursoId");

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("SisEventos.Models.Financia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CaminhoImagem");

                    b.Property<long?>("CursoId");

                    b.Property<string>("Dates")
                        .IsRequired();

                    b.Property<string>("Total")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Financias");
                });

            modelBuilder.Entity("SisEventos.Models.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthToken");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SisEventos.Models.Cliente", b =>
                {
                    b.HasOne("SisEventos.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId");
                });

            modelBuilder.Entity("SisEventos.Models.Estacionamento", b =>
                {
                    b.HasOne("SisEventos.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId");
                });

            modelBuilder.Entity("SisEventos.Models.Evento", b =>
                {
                    b.HasOne("SisEventos.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId");
                });

            modelBuilder.Entity("SisEventos.Models.Financia", b =>
                {
                    b.HasOne("SisEventos.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId");
                });
#pragma warning restore 612, 618
        }
    }
}
