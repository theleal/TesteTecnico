using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudConteiners.Migrations
{
    public partial class migrationV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conteiners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    NumeroConteiner = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    TipoConteiner = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<int>(type: "INT", nullable: false),
                    Categoria = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteiners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMovimentacao = table.Column<int>(type: "INT", nullable: false),
                    DataHoraInicio = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataHoraFim = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ID_Conteiner = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Conteiners_ID_Conteiner",
                        column: x => x.ID_Conteiner,
                        principalTable: "Conteiners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_ID_Conteiner",
                table: "Movimentacoes",
                column: "ID_Conteiner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacoes");

            migrationBuilder.DropTable(
                name: "Conteiners");
        }
    }
}
