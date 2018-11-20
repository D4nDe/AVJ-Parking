using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SisEventos.Migrations
{
    public partial class novo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CursoId",
                table: "Clientes",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Cursos_CursoId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_CursoId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Clientes");
        }
    }
}
