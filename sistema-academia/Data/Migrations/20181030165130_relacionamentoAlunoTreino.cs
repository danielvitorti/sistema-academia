using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sistema_academia.Data.Migrations
{
    public partial class relacionamentoAlunoTreino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Treino",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    objetivo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Alunoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treino", x => x.id);
                    table.ForeignKey(
                        name: "FK_Treino_Aluno_Alunoid",
                        column: x => x.Alunoid,
                        principalTable: "Aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Treino_Alunoid",
                table: "Treino",
                column: "Alunoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Treino");
        }
    }
}
