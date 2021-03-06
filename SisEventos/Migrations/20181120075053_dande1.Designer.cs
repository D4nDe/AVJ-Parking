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
    [Migration("20181120075053_dande1")]
    partial class dande1
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

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.Property<long?>("veiculoId");

                    b.HasKey("Id");

                    b.HasIndex("veiculoId")
                        .IsUnique()
                        .HasFilter("[veiculoId] IS NOT NULL");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SisEventos.Models.Cupom", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.Property<long?>("estacionamentoId");

                    b.HasKey("Id");

                    b.HasIndex("estacionamentoId")
                        .IsUnique()
                        .HasFilter("[estacionamentoId] IS NOT NULL");

                    b.ToTable("Cupons");
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

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Estacionamentos");
                });

            modelBuilder.Entity("SisEventos.Models.Financia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CaminhoImagem");

                    b.Property<string>("Dates")
                        .IsRequired();

                    b.Property<string>("Total")
                        .IsRequired();

                    b.Property<long?>("estacionamentoId");

                    b.HasKey("Id");

                    b.HasIndex("estacionamentoId");

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

            modelBuilder.Entity("SisEventos.Models.Vaga", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<long?>("EstacionamentoId");

                    b.Property<string>("Nome");

                    b.Property<string>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("EstacionamentoId");

                    b.ToTable("Vagas");
                });

            modelBuilder.Entity("SisEventos.Models.Veiculo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CaminhoImagem");

                    b.Property<string>("Descricao");

                    b.Property<string>("Modelo");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("SisEventos.Models.Cliente", b =>
                {
                    b.HasOne("SisEventos.Models.Veiculo", "veiculo")
                        .WithOne("cliente")
                        .HasForeignKey("SisEventos.Models.Cliente", "veiculoId");
                });

            modelBuilder.Entity("SisEventos.Models.Cupom", b =>
                {
                    b.HasOne("SisEventos.Models.Estacionamento", "estacionamento")
                        .WithOne("Cupom")
                        .HasForeignKey("SisEventos.Models.Cupom", "estacionamentoId");
                });

            modelBuilder.Entity("SisEventos.Models.Financia", b =>
                {
                    b.HasOne("SisEventos.Models.Estacionamento", "estacionamento")
                        .WithMany()
                        .HasForeignKey("estacionamentoId");
                });

            modelBuilder.Entity("SisEventos.Models.Vaga", b =>
                {
                    b.HasOne("SisEventos.Models.Estacionamento", "Estacionamento")
                        .WithMany()
                        .HasForeignKey("EstacionamentoId");
                });
#pragma warning restore 612, 618
        }
    }
}
