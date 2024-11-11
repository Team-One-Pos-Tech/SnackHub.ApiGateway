using Microsoft.AspNetCore.Mvc;

namespace SnackHub.Gateway.Controllers
{
    [ApiController]
    [Route("api/order-api/v1")]
    public class OrderController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public OrderController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet()]
        public async Task<ActionResult> GetAll()
        {
            var response = await _httpClient.GetAsync($"http://localhost:5000/api/order/v1/");

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var clientResponse = await response.Content.ReadFromJsonAsync<OrderResponse>();
            return Ok(clientResponse);
        }

        [HttpPut("Confirm")]
        public async Task<ActionResult> UpdateStatus([FromRoute] Guid orderId)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5000/api/order/v1/{orderId}");

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var clientResponse = await response.Content.ReadFromJsonAsync<UpdateKitchenOrderStatusResponse>();
            return Ok(clientResponse);
        }
    }
}
