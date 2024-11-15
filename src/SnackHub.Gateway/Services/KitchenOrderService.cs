using Microsoft.AspNetCore.Mvc;
using SnackHub.Gateway.Models.Client;
using SnackHub.Gateway.Models.KitchenOrder;

namespace SnackHub.Gateway.Services
{
    public class KitchenOrderService
    {
        private readonly HttpClient _httpClient;

        public KitchenOrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<KitchenOrderResponse?> GetAll()
        {
            var response = await _httpClient.GetAsync($"http://localhost:5000/api/kitchenOrder/v1/");           

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<KitchenOrderResponse>();
        }

        public async Task<UpdateKitchenOrderStatusResponse?> UpdateStatus([FromRoute] Guid orderId)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5000/api/kitchenOrder/v1/{orderId}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<UpdateKitchenOrderStatusResponse>();
        }
    }
}
