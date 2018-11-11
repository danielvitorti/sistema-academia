using Microsoft.EntityFrameworkCore.Migrations;

namespace sistema_academia.Data.Migrations
{
    public partial class campoVencimentoAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "valor",
                table: "PagamentoAluno",
                type: "decimal(10,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)");

            migrationBuilder.AddColumn<string>(
                name: "diaVencimento",
                table: "Aluno",
                type: "varchar(1)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "diaVencimento",
                table: "Aluno");

            migrationBuilder.AlterColumn<decimal>(
                name: "valor",
                table: "PagamentoAluno",
                type: "decimal(4,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,4)");
        }
    }
}
