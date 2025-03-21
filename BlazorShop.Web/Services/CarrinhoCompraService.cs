using Azure;
using BlazorShop.Models.DTOs;
using System.Net;
using System.Net.Http.Json;

namespace BlazorShop.Web.Services
{
    public class CarrinhoCompraService : ICarrinhoCompraService
    {
        private readonly HttpClient httpClient;

        public CarrinhoCompraService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<CarrinhoItemDto> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var response = await httpClient
                                .PostAsJsonAsync<CarrinhoItemAdicionaDto>("api/CarrinhoCompra/AdicionaItem", carrinhoItemAdicionaDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(CarrinhoItemDto);
                    }
                    return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code: {response.StatusCode} Mensagem: -{message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CarrinhoItemDto>> GetItens(string usuarioId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/CarrinhoCompra/{usuarioId}/GetItens");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CarrinhoItemDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<CarrinhoItemDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code: {response.StatusCode} Mensagem: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
