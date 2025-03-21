using BlazorShop.Api.Context;
using BlazorShop.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Repositores
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;
        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> GetItem(int id)
        {
            var produto = await _context.Produtos
                .Include(c=>c.Categoria)
                .SingleOrDefaultAsync(c => c.Id == id);

            return produto;
        }

        public async Task<IEnumerable<Produto>> GetItens()
        {
            var produto = await _context.Produtos
                .Include(c => c.Categoria)
                .ToListAsync();

            return produto;
        }

        public async Task<IEnumerable<Produto>> GetItensPorCategoria(int id)
        {
            var produto = await _context.Produtos
                .Include(c => c.Categoria)
                .Where(p => p.CategoriaId == id).ToListAsync();

            return produto;
        }
    }
}
