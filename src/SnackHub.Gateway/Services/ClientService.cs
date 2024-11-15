using SnackHub.Gateway.Models.Client;

namespace SnackHub.Gateway.Services
{
    public class ClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetClientResponse?> GetClientByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5000/api/client/v1/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<GetClientResponse>();
        }

        public async Task<GetClientResponse?> GetClientByCpfAsync(string cpf)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5000/api/client/v1/{cpf}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<GetClientResponse>();
        }
    }
}
