using BlazorShop.Api.Mappings;
using BlazorShop.Api.Repositores;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using CarrinhoItemAdicionaDto = BlazorShop.Api.Repositores.CarrinhoItemAdicionaDto;

namespace BlazorShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoCompraController : ControllerBase
    {
        private readonly ICarrinhoCompraRepository carrinhoCompraRepo;
        private readonly IProdutoRepository produtoRepo;

        private ILogger<CarrinhoCompraController> logger;

        public CarrinhoCompraController(ICarrinhoCompraRepository 
            carrinhoCompraRepository, 
            IProdutoRepository produtoRepository, 
            ILogger<CarrinhoCompraController> logger)
        {
            carrinhoCompraRepo = carrinhoCompraRepository;
            produtoRepo = produtoRepository;
            this.logger = logger;
        }

        [HttpGet]
        [Route("{usuarioId}/GetItens")]
        public async Task<ActionResult<IEnumerable<CarrinhoItemDto>>> GetItens(string usuarioId)
        {
            try
            {
                var carrinhoItens = await carrinhoCompraRepo.GetItens(usuarioId);
                if(carrinhoItens == null)
                {
                    return NoContent();
                }

                var produtos = await this.produtoRepo.GetItens();
                if (produtoRepo == null)
                {
                    throw new Exception("Erro ao obter produtos");
                }

                var carrinhoItensDto = carrinhoItens.ConverterCarrinhoItensParaDto(produtos);
                return Ok(carrinhoItensDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao obter itens do carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter itens do carrinho");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarrinhoItemDto>> GetItem (int id)
        {
            try
            {
                var carrinhoItem = await carrinhoCompraRepo.GetItem(id);
                if (carrinhoItem == null)
                {
                    return NotFound($"Item não encontrado");
                }

                var produto = await produtoRepo.GetItem(carrinhoItem.ProdutoId);

                if(produto == null)
                {
                    return NotFound($"Item não existe na fonte de dados");
                }
                var cartItemDto = carrinhoItem.ConverterCarrinhoItemParaDto(produto);

                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao obter item do carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter item do carrinho");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CarrinhoItemDto>> PostItem([FromBody]
        CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var novoCarrinhoItem = await carrinhoCompraRepo.AdicionaItem(carrinhoItemAdicionaDto);

                if (novoCarrinhoItem == null)
                {
                    return NoContent();
                }

                var produto = await produtoRepo.GetItem(novoCarrinhoItem.ProdutoId);

                if (produto == null)
                {
                    throw new Exception($"Produto não encontrado(id({carrinhoItemAdicionaDto})");
                }

                var novoCarrinhoItemDto = novoCarrinhoItem.ConverterCarrinhoItemParaDto(produto) as CarrinhoItemDto;

                if (novoCarrinhoItemDto == null)
                {
                    throw new Exception("Erro ao converter item do carrinho para DTO");
                }

                return CreatedAtAction(nameof(GetItem), new { id = novoCarrinhoItemDto.Id }, novoCarrinhoItemDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao adicionar item ao carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar item ao carrinho");
            }
        }
    }
}
