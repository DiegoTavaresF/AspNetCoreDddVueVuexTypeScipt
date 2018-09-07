using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Ddd.Infra.Data.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefa");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Concluido = table.Column<bool>(nullable: false),
                    DataDaUltimaAlteracao = table.Column<DateTime>(nullable: true),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeConclusao = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(maxLength: 200, nullable: true),
                    Excluido = table.Column<bool>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                });
        }
    }
}