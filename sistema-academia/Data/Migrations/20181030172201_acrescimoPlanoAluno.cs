using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sistema_academia.Data.Migrations
{
    public partial class acrescimoPlanoAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plano",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    observacao = table.Column<string>(type: "varchar(100)", nullable: false),
                    formaPagamento = table.Column<string>(type: "varchar(100)", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plano", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PlanoAluno",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alunoid = table.Column<int>(nullable: true),
                    Planoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoAluno", x => x.id);
                    table.ForeignKey(
                        name: "FK_PlanoAluno_Aluno_Alunoid",
                        column: x => x.Alunoid,
                        principalTable: "Aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanoAluno_Plano_Planoid",
                        column: x => x.Planoid,
                        principalTable: "Plano",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanoAluno_Alunoid",
                table: "PlanoAluno",
                column: "Alunoid");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoAluno_Planoid",
                table: "PlanoAluno",
                column: "Planoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanoAluno");

            migrationBuilder.DropTable(
                name: "Plano");
        }
    }
}
