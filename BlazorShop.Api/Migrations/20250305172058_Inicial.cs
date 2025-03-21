using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorShop.Api.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IconCSS = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrinhos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrinhoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrinhoItems_Carrinhos_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarrinhoItems_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "IconCSS", "Nome" },
                values: new object[,]
                {
                    { 1, "fas fa-car", "Carros" },
                    { 2, "fas fa-motorcycle", "Motos" },
                    { 3, "fas fa-tools", "Acessórios" },
                    { 4, "fas fa-cogs", "Peças" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "NomeUsuario" },
                values: new object[,]
                {
                    { 1, "Alex Santana" },
                    { 2, "Hugo Souza" },
                    { 3, "Breno Bidon" },
                    { 4, "Talles Magno" }
                });

            migrationBuilder.InsertData(
                table: "Carrinhos",
                columns: new[] { "Id", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaId", "Descricao", "ImagemUrl", "Nome", "Preco", "Quantidade" },
                values: new object[,]
                {
                    { 1, 1, "2006, Prata - Sedan. Com 150 mil km rodados ainda está em bom estado", "https://via.placeholder.com/150", "Civic - Honda", 25000m, 1 },
                    { 2, 1, "2015, Preto - Sedan. Pouco rodado, bem conservado", "https://via.placeholder.com/150", "Corolla - Toyota", 60000m, 1 },
                    { 3, 1, "2019, Branco - Hatch. Econômico e com baixa quilometragem", "https://via.placeholder.com/150", "Onix - Chevrolet", 45000m, 1 },
                    { 4, 1, "2012, Vermelho - Hatch. Excelente para o dia a dia", "https://via.placeholder.com/150", "Gol - Volkswagen", 30000m, 1 },
                    { 5, 1, "2014, Cinza - Hatch. Completo e bem cuidado", "https://via.placeholder.com/150", "Fiesta - Ford", 35000m, 1 },
                    { 6, 2, "2020, Preta - Motocicleta esportiva, potente e confortável", "https://via.placeholder.com/150", "CB 500 - Honda", 28000m, 1 },
                    { 7, 2, "2021, Azul - Naked com motor bicilíndrico potente", "https://via.placeholder.com/150", "MT-07 - Yamaha", 38000m, 1 },
                    { 8, 2, "2022, Verde - Esportiva, perfeita para quem quer adrenalina", "https://via.placeholder.com/150", "Ninja 400 - Kawasaki", 35000m, 1 },
                    { 9, 2, "2020, Vermelha - Trail ideal para estradas de terra", "https://via.placeholder.com/150", "XRE 300 - Honda", 25000m, 1 },
                    { 10, 2, "2019, Branca - Econômica e confortável para viagens", "https://via.placeholder.com/150", "Fazer 250 - Yamaha", 20000m, 1 },
                    { 11, 3, "Capacete LS2 FF320, viseira dupla, cor preta", "https://via.placeholder.com/150", "Capacete LS2", 800m, 5 },
                    { 12, 4, "Par de pneus Pirelli para motocicletas esportivas", "https://via.placeholder.com/150", "Jogo de Pneus Pirelli", 1200m, 3 },
                    { 13, 4, "Kit relação para motos 250cc, corrente, coroa e pinhão", "https://via.placeholder.com/150", "Kit Relação - DID", 600m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItems_CarrinhoId",
                table: "CarrinhoItems",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItems_ProdutoId",
                table: "CarrinhoItems",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_UsuarioId",
                table: "Carrinhos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoItems");

            migrationBuilder.DropTable(
                name: "Carrinhos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
