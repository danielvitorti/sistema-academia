using Microsoft.EntityFrameworkCore.Migrations;

namespace sistema_academia.Data.Migrations
{
    public partial class trocaTiposDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "observacao",
                table: "Treino",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tempo",
                table: "ExercicioTreino",
                type: "decimal(3,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<decimal>(
                name: "peso",
                table: "ExercicioTreino",
                type: "decimal(3,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddColumn<string>(
                name: "observacao",
                table: "ExercicioTreino",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "observacao",
                table: "Treino");

            migrationBuilder.DropColumn(
                name: "observacao",
                table: "ExercicioTreino");

            migrationBuilder.AlterColumn<string>(
                name: "tempo",
                table: "ExercicioTreino",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");

            migrationBuilder.AlterColumn<string>(
                name: "peso",
                table: "ExercicioTreino",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");
        }
    }
}
