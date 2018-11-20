using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SisEventos.Migrations
{
    public partial class estacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Estacionamentos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Estacionamentos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CaminhoImagem",
                table: "Estacionamentos",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CursoId",
                table: "Estacionamentos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamentos_CursoId",
                table: "Estacionamentos",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estacionamentos_Cursos_CursoId",
                table: "Estacionamentos",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estacionamentos_Cursos_CursoId",
                table: "Estacionamentos");

            migrationBuilder.DropIndex(
                name: "IX_Estacionamentos_CursoId",
                table: "Estacionamentos");

            migrationBuilder.DropColumn(
                name: "CaminhoImagem",
                table: "Estacionamentos");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Estacionamentos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Estacionamentos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Estacionamentos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
