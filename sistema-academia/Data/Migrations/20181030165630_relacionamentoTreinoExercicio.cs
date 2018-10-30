using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sistema_academia.Data.Migrations
{
    public partial class relacionamentoTreinoExercicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExercicioTreino",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    peso = table.Column<string>(type: "varchar(100)", nullable: false),
                    tempo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Treinoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercicioTreino", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExercicioTreino_Treino_Treinoid",
                        column: x => x.Treinoid,
                        principalTable: "Treino",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioTreino_Treinoid",
                table: "ExercicioTreino",
                column: "Treinoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExercicioTreino");
        }
    }
}
