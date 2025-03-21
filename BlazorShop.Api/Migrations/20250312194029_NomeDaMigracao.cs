using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorShop.Api.Migrations
{
    public partial class NomeDaMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagemUrl",
                value: "/imagens/carros/carro1.png");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagemUrl",
                value: "/imagens/carros/carro2.png");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagemUrl",
                value: "/imagens/carros/carro3.png");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagemUrl",
                value: "/imagens/carros/carro4.png");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImagemUrl",
                value: "/imagens/carros/carro5.png");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImagemUrl",
                value: "/imagens/motos/moto1.png");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImagemUrl",
                value: "/imagens/motos/moto2.png");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImagemUrl",
                value: "/imagens/motos/moto3.png");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImagemUrl",
                value: "/imagens/motos/moto4.png");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImagemUrl",
                value: "/imagens/motos/moto5.png");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImagemUrl",
                value: "/imagens/itens/item1.png");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImagemUrl",
                value: "/imagens/itens/item2.png");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImagemUrl",
                value: "/imagens/itens/item3.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagemUrl",
                value: "https://via.placeholder.com/150");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagemUrl",
                value: "https://via.placeholder.com/150");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagemUrl",
                value: "https://via.placeholder.com/150");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagemUrl",
                value: "https://via.placeholder.com/150");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImagemUrl",
                value: "https://via.placeholder.com/150");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImagemUrl",
                value: "https://via.placeholder.com/150");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImagemUrl",
                value: "https://via.placeholder.com/150");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImagemUrl",
                value: "https://via.placeholder.com/150");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImagemUrl",
                value: "https://via.placeholder.com/150");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImagemUrl",
                value: "https://via.placeholder.com/150");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImagemUrl",
                value: "https://via.placeholder.com/150");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImagemUrl",
                value: "https://via.placeholder.com/150");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImagemUrl",
                value: "https://via.placeholder.com/150");
        }
    }
}
