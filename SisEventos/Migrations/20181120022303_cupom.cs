using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SisEventos.Migrations
{
    public partial class cupom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cupons",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    estacionamentoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cupons_Estacionamentos_estacionamentoId",
                        column: x => x.estacionamentoId,
                        principalTable: "Estacionamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cupons_estacionamentoId",
                table: "Cupons",
                column: "estacionamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cupons");
        }
    }
}
