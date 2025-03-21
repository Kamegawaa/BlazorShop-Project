using BlazorShop.Api.Mappings;
using BlazorShop.Api.Repositores;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItens()
        {
            try
            {
                var produtos = await _produtoRepository.GetItens();
                if (produtos is null)
                {
                    return NotFound();
                }
                else
                {
                    var produtosDtos = produtos.ConverterProdutosParaDto();
                    return Ok(produtosDtos);
                }
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar os produtos");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoDto>> GetItem(int id)
        {
            try
            {
                var produto = await _produtoRepository.GetItem(id);
                if (produto is null)
                {
                    return NotFound("Produto não localizado");
                }
                else
                {
                    var produtoDto = produto.ConverterProdutoParaDto();
                    return Ok(produtoDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar o produto");
            }
        }

        [HttpGet]
        [Route("categoria/{id:int}")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> 
            GetItensPorCategoria(int categoriaId)
        {
            try
            {
                var produtos = await _produtoRepository.GetItensPorCategoria(categoriaId);
                var produtosDtos = produtos.ConverterProdutosParaDto();
                return Ok(produtosDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar os produtos");
            }
        }
    }
}
