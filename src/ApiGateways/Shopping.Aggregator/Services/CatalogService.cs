using Shopping.Aggregator.Extentions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            var response = await _httpClient.GetAsync("/api/v1/Catalog");
            return await response.ReadContentAt<List<CatalogModel>>();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string categoryName)
        {
            var response = await _httpClient.GetAsync($"/api/v1/Catalog/GetProductByCategory/{categoryName}");
            return await response.ReadContentAt<List<CatalogModel>>();
        }

        public async Task<CatalogModel> GetCatalogById(string id)
        {
            var response = await _httpClient.GetAsync($"/api/v1/Catalog/{id}");
            return await response.ReadContentAt<CatalogModel>();
        }
    }
}
