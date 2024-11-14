using Microsoft.AspNetCore.Mvc;
using SnackHub.Gateway.Models.Order;
using System.Net.Http.Json;

namespace SnackHub.Api.Gateway.Controllers
{
    [ApiController]
    [Route("order-api/v1")]
    public class OrderController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public OrderController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var response = await _httpClient.GetAsync("http://localhost:5000/api/order/v1");
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var orders = await response.Content.ReadFromJsonAsync<IEnumerable<OrderResponse>>();
            return Ok(orders);
        }

        [HttpPost("Confirm")]
        public async Task<ActionResult> Confirm([FromBody] ConfirmOrderRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/order/v1/Confirm", request);
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var confirmResponse = await response.Content.ReadFromJsonAsync<ConfirmOrderResponse>();
            return Ok(confirmResponse);
        }

        [HttpPut("Cancel")]
        public async Task<ActionResult> Cancel([FromBody] CancelOrderRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync("http://localhost:5000/api/order/v1/Cancel", request);
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var cancelResponse = await response.Content.ReadFromJsonAsync<CancelOrderResponse>();
            return Ok(cancelResponse);
        }

        [HttpPost("Checkout")]
        public async Task<ActionResult> Checkout([FromBody] CheckoutOrderRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/order/v1/Checkout", request);
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var checkoutResponse = await response.Content.ReadFromJsonAsync<CheckoutOrderResponse>();
            return Ok(checkoutResponse);
        }

        [HttpGet("{orderId:guid}/payment-status")]
        public async Task<ActionResult> CheckPaymentStatus(Guid orderId)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5000/api/order/v1/{orderId}/payment-status");
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var paymentStatusResponse = await response.Content.ReadFromJsonAsync<CheckPaymentStatusResponse>();
            return Ok(paymentStatusResponse);
        }

        [HttpPut("{orderId:guid}/status")]
        public async Task<ActionResult> UpdateOrderStatus(Guid orderId)
        {
            var response = await _httpClient.PutAsJsonAsync($"http://localhost:5000/api/order/v1/{orderId}/status", new { OrderId = orderId });
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var updateStatusResponse = await response.Content.ReadFromJsonAsync<UpdateOrderStatusResponse>();
            return Ok(updateStatusResponse);
        }
    }
}
