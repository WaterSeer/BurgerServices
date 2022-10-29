using Shopping.Aggregator.Extentions;
using Shopping.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentException(nameof(httpClient));
        }

        public async Task<BasketModel> GetBasket(string userName)
        {
            var response = await _httpClient.GetAsync($"/api/v1/Basket/{userName}");
            return await response.ReadContentAt<BasketModel>();
        }
    }
}
