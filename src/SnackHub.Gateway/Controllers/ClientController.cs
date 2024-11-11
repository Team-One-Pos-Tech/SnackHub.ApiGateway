using Microsoft.AspNetCore.Mvc;
using SnackHub.Gateway.Models.Client;

namespace SnackHub.Api.Gateway.Controllers
{
    [ApiController]
    [Route("client-api/v1")]
    public class ClientController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ClientController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById([FromRoute] Guid id)
        {
            // Define o URL do microserviço de Client para a requisição
            var response = await _httpClient.GetAsync($"http://localhost:5000/api/client/v1/{id}");

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var clientResponse = await response.Content.ReadFromJsonAsync<GetClientResponse>();
            return Ok(clientResponse);
        }

        [HttpGet("GetByCpf")]
        public async Task<ActionResult> GetByCpf([FromRoute] string cpf)
        {
            // Define o URL do microserviço de Client para a requisição
            var response = await _httpClient.GetAsync($"http://localhost:5000/api/client/v1/{cpf}");

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var clientResponse = await response.Content.ReadFromJsonAsync<GetClientResponse>();
            return Ok(clientResponse);
        }
    }
}
