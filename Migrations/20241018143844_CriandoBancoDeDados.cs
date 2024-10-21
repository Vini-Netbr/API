using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class CriandoBancoDeDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Tabela Produtos
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "serial", nullable: false), // PostgreSQL usa 'serial' para auto incremento
                    Produto = table.Column<string>(type: "varchar(255)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(255)", nullable: true), // permite nulos
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    Preco = table.Column<decimal>(type: "numeric(10,2)", nullable: false) // 'numeric' é o tipo de dados equivalente para decimal
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            // Tabela Usuarios
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "serial", nullable: false), // 'serial' para auto incremento
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(255)", nullable: false),
                    Funcao = table.Column<string>(type: "varchar(50)", nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.UniqueConstraint("AK_Usuarios_Email", x => x.Email); // Email único
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}

