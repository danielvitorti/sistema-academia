using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sistema_academia.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    sexo = table.Column<string>(type: "char(1)", nullable: false),
                    enderecoCep = table.Column<string>(type: "varchar(100)", nullable: true),
                    enderecoRua = table.Column<string>(type: "varchar(100)", nullable: false),
                    enderecoNumero = table.Column<string>(type: "char(15)", nullable: false),
                    enderecoBairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    enderecoCidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    enderecoEstado = table.Column<string>(type: "varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");
        }
    }
}
