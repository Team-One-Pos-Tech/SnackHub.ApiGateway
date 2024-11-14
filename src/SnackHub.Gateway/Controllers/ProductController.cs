using Microsoft.AspNetCore.Mvc;
using SnackHub.Gateway.Models.Product;
using System.Net.Http.Json;

namespace SnackHub.Api.Gateway.Controllers
{
    [ApiController]
    [Route("product-api/v1")]
    public class ProductController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ProductController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5000/api/product/v1/{id}");
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var productResponse = await response.Content.ReadFromJsonAsync<GetProductResponse>();
            return Ok(productResponse);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = await _httpClient.GetAsync("http://localhost:5000/api/product/v1");
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var products = await response.Content.ReadFromJsonAsync<IEnumerable<GetProductResponse>>();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ManageProductRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/product/v1", request);
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var manageProductResponse = await response.Content.ReadFromJsonAsync<ManageProductResponse>();
            return Ok(manageProductResponse);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, ManageProductRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync($"http://localhost:5000/api/product/v1/{id}", request);
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var manageProductResponse = await response.Content.ReadFromJsonAsync<ManageProductResponse>();
            return Ok(manageProductResponse);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5000/api/product/v1/{id}");
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            return NoContent();
        }

        [HttpGet("category/{category:int}")]
        public async Task<ActionResult> GetByCategory([FromRoute] int category)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5000/api/product/v1/{category}");
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var products = await response.Content.ReadFromJsonAsync<IEnumerable<GetProductResponse>>();
            return Ok(products);
        }
    }
}