using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SisEventos.Migrations
{
    public partial class clienteveiculos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Cursos_CursoId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Estacionamentos_Cursos_CursoId",
                table: "Estacionamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Clientes_clienteId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_clienteId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Estacionamentos_CursoId",
                table: "Estacionamentos");

            migrationBuilder.DropIndex(
                name: "IX_Cupons_estacionamentoId",
                table: "Cupons");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_CursoId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "clienteId",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Estacionamentos");

            migrationBuilder.RenameColumn(
                name: "CursoId",
                table: "Clientes",
                newName: "veiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cupons_estacionamentoId",
                table: "Cupons",
                column: "estacionamentoId",
                unique: true,
                filter: "[estacionamentoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_veiculoId",
                table: "Clientes",
                column: "veiculoId",
                unique: true,
                filter: "[veiculoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Veiculos_veiculoId",
                table: "Clientes",
                column: "veiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Veiculos_veiculoId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Cupons_estacionamentoId",
                table: "Cupons");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_veiculoId",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "veiculoId",
                table: "Clientes",
                newName: "CursoId");

            migrationBuilder.AddColumn<long>(
                name: "clienteId",
                table: "Veiculos",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CursoId",
                table: "Estacionamentos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_clienteId",
                table: "Veiculos",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamentos_CursoId",
                table: "Estacionamentos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cupons_estacionamentoId",
                table: "Cupons",
                column: "estacionamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CursoId",
                table: "Clientes",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Cursos_CursoId",
                table: "Clientes",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estacionamentos_Cursos_CursoId",
                table: "Estacionamentos",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Clientes_clienteId",
                table: "Veiculos",
                column: "clienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
