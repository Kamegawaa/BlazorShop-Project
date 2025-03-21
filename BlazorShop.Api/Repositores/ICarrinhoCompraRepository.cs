using BlazorShop.Api.Controllers;
using BlazorShop.Api.Entities;
using BlazorShop.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Api.Repositores
{
    public class CarrinhoItemAdicionaDto
    {
        [Required]
        public int CarrinhoId { get; set; }
        [Required]
        public int ProdutoId { get; set; }
        [Required]
        public int Quantidade { get; set; }
    }
    public interface ICarrinhoCompraRepository
    {
        Task<CarrinhoItem> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);
        Task AdicionaItem(CarrinhoItemAdicionadoDto carrinhoItemAdicionadoDto);
        Task AdicionaItem(object carrinhoItemAdicionaDto);
        Task<CarrinhoItem> AtualizaQuantidade(int id, CarrinhoItemAtualizaQuantidadeDto
            carrinhoItemAtualizaQuantidadeDto);

        Task<CarrinhoItem> DeletarItem(int id);

        Task<CarrinhoItem> GetItem(int id);

        Task<IEnumerable<CarrinhoItem>> GetItens(string usuarioID);
    }
}
