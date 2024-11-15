using Microsoft.AspNetCore.Mvc;
using SnackHub.Gateway.Services;

namespace SnackHub.Api.Gateway.Controllers
{
    [ApiController]
    [Route("client-api/v1")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById([FromRoute] Guid id)
        {
            var clientResponse = await _clientService.GetClientByIdAsync(id);

            if (clientResponse == null)
                return NotFound("Client not found");

            return Ok(clientResponse);
        }

        [HttpGet("GetByCpf")]
        public async Task<ActionResult> GetByCpf([FromRoute] string cpf)
        {
            var clientResponse = await _clientService.GetClientByCpfAsync(cpf);

            if (clientResponse == null)
                return NotFound("Client not found");

            return Ok(clientResponse);
        }
    }
}
