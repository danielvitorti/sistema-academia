using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sistema_academia.Data.Migrations
{
    public partial class acrescimoCampoDataCadastro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dataCadastro",
                table: "Treino",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dataCadastro",
                table: "ExercicioTreino",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dataCadastro",
                table: "Aluno",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataCadastro",
                table: "Treino");

            migrationBuilder.DropColumn(
                name: "dataCadastro",
                table: "ExercicioTreino");

            migrationBuilder.DropColumn(
                name: "dataCadastro",
                table: "Aluno");
        }
    }
}
