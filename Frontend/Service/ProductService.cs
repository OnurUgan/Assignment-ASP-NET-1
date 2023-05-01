using Frontend.Models;
using Newtonsoft.Json;

namespace Frontend.Service
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            var response = await _httpClient.GetAsync($"https://localhost:7003/api/Products?key=MyKey");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var apiproducts = JsonConvert.DeserializeObject<List<ProductModel>>(content);

            return apiproducts;
        }

        public async Task<ProductModel> GetById(string id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7003/api/Products/id/{id}?key=MyKey");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var apiproduct = JsonConvert.DeserializeObject<ProductModel>(content);

            return apiproduct;
        }
    }
}
