using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleEFCore.Migrations
{
    public partial class v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id", "Alergias", "Idade", "Nome", "Sexo" },
                values: new object[] { 1, "Abelha;Formiga", 38, "Carlos Eduardo", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
