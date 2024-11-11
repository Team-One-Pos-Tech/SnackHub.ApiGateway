using Microsoft.AspNetCore.Mvc;
using SnackHub.Gateway.Models.KitchenOrder;

namespace SnackHub.Gateway.Controllers
{
    [ApiController]
    [Route("api/kitchen-api/v1")]
    public class KitchenOrderController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public KitchenOrderController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var response = await _httpClient.GetAsync($"http://localhost:5000/api/kitchenOrder/v1/");

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var kitchenOrderResponse = await response.Content.ReadFromJsonAsync<KitchenOrderResponse>();
            return Ok(kitchenOrderResponse);
        }

        [HttpPut("UpdateStatus")]
        public async Task<ActionResult> UpdateStatus([FromRoute] Guid orderId)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5000/api/kitchenOrder/v1/{orderId}");

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var kitchenOrderResponse = await response.Content.ReadFromJsonAsync<UpdateKitchenOrderStatusResponse>();
            return Ok(kitchenOrderResponse);
        }
    }
}
