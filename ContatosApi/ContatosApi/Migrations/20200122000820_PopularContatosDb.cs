using Microsoft.EntityFrameworkCore.Migrations;

namespace ContatosApi.Migrations
{
    public partial class PopularContatosDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Contatos(Nome, Email,Telefone) Values('Luiz','Luiz.felipe@gmail.com','33349910')");
            migrationBuilder.Sql("Insert into Contatos(Nome, Email,Telefone) Values('pedro','pedro.souza@gmail.com','333455910')");
            migrationBuilder.Sql("Insert into Contatos(Nome, Email,Telefone) Values('junior','junior.alvez@gmail.com','33459910')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From Contatos");

        }
    }
}
