using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleEFCore.Migrations
{
    public partial class _16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "integer", nullable: false),
                    Logradouro = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.PacienteId);
                    table.ForeignKey(
                        name: "FK_Enderecos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "PacienteId", "Logradouro", "Numero" },
                values: new object[] { 1, "Avenida X", 304 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
