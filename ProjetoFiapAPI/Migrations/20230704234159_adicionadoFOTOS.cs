using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFiapAPI.Migrations
{
    public partial class adicionadoFOTOS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Cadastro",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Cadastro");
        }
    }
}
