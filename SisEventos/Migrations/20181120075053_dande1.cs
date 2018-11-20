using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SisEventos.Migrations
{
    public partial class dande1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financias_Cursos_CursoId",
                table: "Financias");

            migrationBuilder.DropColumn(
                name: "CaminhoImagem",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "CursoId",
                table: "Financias",
                newName: "estacionamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Financias_CursoId",
                table: "Financias",
                newName: "IX_Financias_estacionamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Financias_Estacionamentos_estacionamentoId",
                table: "Financias",
                column: "estacionamentoId",
                principalTable: "Estacionamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financias_Estacionamentos_estacionamentoId",
                table: "Financias");

            migrationBuilder.RenameColumn(
                name: "estacionamentoId",
                table: "Financias",
                newName: "CursoId");

            migrationBuilder.RenameIndex(
                name: "IX_Financias_estacionamentoId",
                table: "Financias",
                newName: "IX_Financias_CursoId");

            migrationBuilder.AddColumn<string>(
                name: "CaminhoImagem",
                table: "Clientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Clientes",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Financias_Cursos_CursoId",
                table: "Financias",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
