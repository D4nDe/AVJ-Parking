using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SisEventos.Migrations
{
    public partial class ola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Clientes_CursoId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_CursoId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Clientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Clientes");

            migrationBuilder.AddColumn<long>(
                name: "CursoId",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CursoId",
                table: "Clientes",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Clientes_CursoId",
                table: "Clientes",
                column: "CursoId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
