using BlazorShop.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Web.Services
{
    public interface ICarrinhoCompraService
    {
        Task<List<CarrinhoItemDto>> GetItens(string usuarioId);
        Task<CarrinhoItemDto> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);
    }
}