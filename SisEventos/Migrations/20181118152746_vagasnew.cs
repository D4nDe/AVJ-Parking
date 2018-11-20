using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SisEventos.Migrations
{
    public partial class vagasnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Cursos_CursoId",
                table: "Vagas");

            migrationBuilder.RenameColumn(
                name: "CursoId",
                table: "Vagas",
                newName: "EstacionamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vagas_CursoId",
                table: "Vagas",
                newName: "IX_Vagas_EstacionamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Estacionamentos_EstacionamentoId",
                table: "Vagas",
                column: "EstacionamentoId",
                principalTable: "Estacionamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Estacionamentos_EstacionamentoId",
                table: "Vagas");

            migrationBuilder.RenameColumn(
                name: "EstacionamentoId",
                table: "Vagas",
                newName: "CursoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vagas_EstacionamentoId",
                table: "Vagas",
                newName: "IX_Vagas_CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Cursos_CursoId",
                table: "Vagas",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
