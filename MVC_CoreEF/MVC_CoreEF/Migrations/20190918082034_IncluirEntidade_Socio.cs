using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_CoreEF.Migrations
{
    public partial class IncluirEntidade_Socio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoSocioId",
                table: "Alunos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Socio",
                columns: table => new
                {
                    TipoSocioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Duracao = table.Column<int>(nullable: false),
                    TaxaDesconto = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socio", x => x.TipoSocioId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TipoSocioId",
                table: "Alunos",
                column: "TipoSocioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Socio_TipoSocioId",
                table: "Alunos",
                column: "TipoSocioId",
                principalTable: "Socio",
                principalColumn: "TipoSocioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Socio_TipoSocioId",
                table: "Alunos");

            migrationBuilder.DropTable(
                name: "Socio");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TipoSocioId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TipoSocioId",
                table: "Alunos");
        }
    }
}
