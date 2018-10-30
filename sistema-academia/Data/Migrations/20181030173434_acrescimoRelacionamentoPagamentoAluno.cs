using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sistema_academia.Data.Migrations
{
    public partial class acrescimoRelacionamentoPagamentoAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PagamentoAluno",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(type: "varchar(255)", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    tipoPagamento = table.Column<string>(type: "char(1)", nullable: false),
                    Alunoid = table.Column<int>(nullable: true),
                    Planoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoAluno", x => x.id);
                    table.ForeignKey(
                        name: "FK_PagamentoAluno_Aluno_Alunoid",
                        column: x => x.Alunoid,
                        principalTable: "Aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagamentoAluno_Plano_Planoid",
                        column: x => x.Planoid,
                        principalTable: "Plano",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoAluno_Alunoid",
                table: "PagamentoAluno",
                column: "Alunoid");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoAluno_Planoid",
                table: "PagamentoAluno",
                column: "Planoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagamentoAluno");
        }
    }
}
