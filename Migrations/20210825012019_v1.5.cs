using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleEFCore.Migrations
{
    public partial class v15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnfermariaMedico",
                columns: table => new
                {
                    EnfermariaId = table.Column<int>(type: "integer", nullable: false),
                    MedicoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnfermariaMedico", x => new { x.EnfermariaId, x.MedicoId });
                    table.ForeignKey(
                        name: "FK_EnfermariaMedico_Enfermarias_EnfermariaId",
                        column: x => x.EnfermariaId,
                        principalTable: "Enfermarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnfermariaMedico_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Enfermarias",
                columns: new[] { "Id", "Descricao", "NumeroDeLeitos" },
                values: new object[] { 1, "Covid", 10 });

            migrationBuilder.InsertData(
                table: "EnfermariaMedico",
                columns: new[] { "EnfermariaId", "MedicoId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_EnfermariaMedico_MedicoId",
                table: "EnfermariaMedico",
                column: "MedicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnfermariaMedico");

            migrationBuilder.DeleteData(
                table: "Enfermarias",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
