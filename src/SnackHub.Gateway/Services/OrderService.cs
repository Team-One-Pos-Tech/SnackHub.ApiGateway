using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnackHub.Gateway.Models.Client;
using SnackHub.Gateway.Models.Order;

namespace SnackHub.Gateway.Services
{
    public class OrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OrderResponse?> GetAll()
        {
            var response = await _httpClient.GetAsync("http://localhost:5000/api/order/v1");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<OrderResponse>();           
        }

        public async Task<ConfirmOrderResponse?> Confirm([FromBody] ConfirmOrderRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/order/v1/Confirm", request);
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<ConfirmOrderResponse>();
        }

        public async Task<CancelOrderResponse?> Cancel([FromBody] CancelOrderRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync("http://localhost:5000/api/order/v1/Cancel", request);
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<CancelOrderResponse>();
        }

        public async Task<CheckoutOrderResponse?> Checkout([FromBody] CheckoutOrderRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/order/v1/Checkout", request);
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<CheckoutOrderResponse>();
        }

        public async Task<CheckPaymentStatusResponse?> CheckPaymentStatus(Guid orderId)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5000/api/order/v1/{orderId}/payment-status");
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<CheckPaymentStatusResponse>();
        }

        public async Task<UpdateOrderStatusResponse?> UpdateOrderStatus(Guid orderId)
        {
            var response = await _httpClient.PutAsJsonAsync($"http://localhost:5000/api/order/v1/{orderId}/status", new { OrderId = orderId });
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<UpdateOrderStatusResponse>();
        }
    }
}
