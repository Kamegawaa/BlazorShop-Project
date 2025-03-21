using BlazorShop.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Context
{
    public class AppDbContext : DbContext
    {
        internal object CarrinhoItens;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Carrinho>? Carrinhos { get; set; }
        public DbSet<CarrinhoItem>? CarrinhoItems { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Categorias
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "Carros", IconCSS = "fas fa-car" },
                new Categoria { Id = 2, Nome = "Motos", IconCSS = "fas fa-motorcycle" },
                new Categoria { Id = 3, Nome = "Acessórios", IconCSS = "fas fa-tools" },
                new Categoria { Id = 4, Nome = "Peças", IconCSS = "fas fa-cogs" }
            );

            // Produtos - Carros
            modelBuilder.Entity<Produto>().HasData(
                new Produto { Id = 1, Nome = "Civic - Honda", Descricao = "2006, Prata - Sedan. Com 150 mil km rodados ainda está em bom estado", ImagemUrl = "/imagens/carros/carro1.png", Preco = 25000, Quantidade = 1, CategoriaId = 1 },
                new Produto { Id = 2, Nome = "Corolla - Toyota", Descricao = "2015, Preto - Sedan. Pouco rodado, bem conservado", ImagemUrl = "/imagens/carros/carro2.png", Preco = 60000, Quantidade = 1, CategoriaId = 1 },
                new Produto { Id = 3, Nome = "Onix - Chevrolet", Descricao = "2019, Branco - Hatch. Econômico e com baixa quilometragem", ImagemUrl = "/imagens/carros/carro3.png", Preco = 45000, Quantidade = 1, CategoriaId = 1 },
                new Produto { Id = 4, Nome = "Gol - Volkswagen", Descricao = "2012, Vermelho - Hatch. Excelente para o dia a dia", ImagemUrl = "/imagens/carros/carro4.png", Preco = 30000, Quantidade = 1, CategoriaId = 1 },
                new Produto { Id = 5, Nome = "Fiesta - Ford", Descricao = "2014, Cinza - Hatch. Completo e bem cuidado", ImagemUrl = "/imagens/carros/carro5.png", Preco = 35000, Quantidade = 1, CategoriaId = 1 }
            );

            // Produtos - Motos
            modelBuilder.Entity<Produto>().HasData(
                new Produto { Id = 6, Nome = "CB 500 - Honda", Descricao = "2020, Preta - Motocicleta esportiva, potente e confortável", ImagemUrl = "/imagens/motos/moto1.png", Preco = 28000, Quantidade = 1, CategoriaId = 2 },
                new Produto { Id = 7, Nome = "MT-07 - Yamaha", Descricao = "2021, Azul - Naked com motor bicilíndrico potente", ImagemUrl = "/imagens/motos/moto2.png", Preco = 38000, Quantidade = 1, CategoriaId = 2 },
                new Produto { Id = 8, Nome = "Ninja 400 - Kawasaki", Descricao = "2022, Verde - Esportiva, perfeita para quem quer adrenalina", ImagemUrl = "/imagens/motos/moto3.png", Preco = 35000, Quantidade = 1, CategoriaId = 2 },
                new Produto { Id = 9, Nome = "XRE 300 - Honda", Descricao = "2020, Vermelha - Trail ideal para estradas de terra", ImagemUrl = "/imagens/motos/moto4.png", Preco = 25000, Quantidade = 1, CategoriaId = 2 },
                new Produto { Id = 10, Nome = "Fazer 250 - Yamaha", Descricao = "2019, Branca - Econômica e confortável para viagens", ImagemUrl = "/imagens/motos/moto5.png", Preco = 20000, Quantidade = 1, CategoriaId = 2 }
            );

            // Produtos - Acessórios e Peças
            modelBuilder.Entity<Produto>().HasData(
                new Produto { Id = 11, Nome = "Capacete LS2", Descricao = "Capacete LS2 FF320, viseira dupla, cor preta", ImagemUrl = "/imagens/itens/item1.png", Preco = 800, Quantidade = 5, CategoriaId = 3 },
                new Produto { Id = 12, Nome = "Jogo de Pneus Pirelli", Descricao = "Par de pneus Pirelli para motocicletas esportivas", ImagemUrl = "/imagens/itens/item2.png", Preco = 1200, Quantidade = 3, CategoriaId = 4 },
                new Produto { Id = 13, Nome = "Kit Relação - DID", Descricao = "Kit relação para motos 250cc, corrente, coroa e pinhão", ImagemUrl = "/imagens/itens/item3.png", Preco = 600, Quantidade = 2, CategoriaId = 4 }
            );

            // Usuários
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, NomeUsuario = "Alex Santana" },
                new Usuario { Id = 2, NomeUsuario = "Hugo Souza" },
                new Usuario { Id = 3, NomeUsuario = "Breno Bidon" },
                new Usuario { Id = 4, NomeUsuario = "Talles Magno" }
            );

            // Carrinhos para os Usuários
            modelBuilder.Entity<Carrinho>().HasData(
                new Carrinho { Id = 1, UsuarioId = 1 },
                new Carrinho { Id = 2, UsuarioId = 2 },
                new Carrinho { Id = 3, UsuarioId = 3 },
                new Carrinho { Id = 4, UsuarioId = 4 }
            );
        }
    }
}