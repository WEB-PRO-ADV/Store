using System;
using Store.Core.Interfaces;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;

namespace Store.Infrastructure
{
    public class SupplierService : ISupplierService
    {
        private readonly ILogger<SupplierService> _logger;

        HttpClientHandler _clientHandler = new HttpClientHandler();

        public SupplierService(ILogger<SupplierService> logger)
        {
            _logger = logger;
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        public async Task<string> GetItemsAsync()
        {
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44358/api/products/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }
            }
            throw new NotImplementedException();
        }



        public async Task<string> GetItemByCodeAsync(string code)
        {
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44358/api/products/code/" + code))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }
            }
            throw new NotImplementedException();
        }
        public async Task<string> GetCategoriesAsync()
        {
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44358/api/categories/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }
            }
            throw new NotImplementedException();
        }
    }
}
