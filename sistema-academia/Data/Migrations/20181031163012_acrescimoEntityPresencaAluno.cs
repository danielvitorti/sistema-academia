using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sistema_academia.Data.Migrations
{
    public partial class acrescimoEntityPresencaAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dataCadastro",
                table: "PlanoAluno",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "PresencaAluno",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alunoid = table.Column<int>(nullable: true),
                    dataPresenca = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresencaAluno", x => x.id);
                    table.ForeignKey(
                        name: "FK_PresencaAluno_Aluno_Alunoid",
                        column: x => x.Alunoid,
                        principalTable: "Aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PresencaAluno_Alunoid",
                table: "PresencaAluno",
                column: "Alunoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresencaAluno");

            migrationBuilder.DropColumn(
                name: "dataCadastro",
                table: "PlanoAluno");
        }
    }
}
