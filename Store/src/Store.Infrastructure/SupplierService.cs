using System;
using Store.Core.Interfaces;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Store.Core.ValueObject;
using Newtonsoft.Json;

namespace Store.Infrastructure
{
    public class SupplierService : ISupplierService
    {
        private readonly ILogger<SupplierService> _logger;

        HttpClientHandler _clientHandler = new HttpClientHandler();
        IConfiguration Configuration;

        public SupplierService(ILogger<SupplierService> logger, IConfiguration _configuration)
        {
            _logger = logger;
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            Configuration = _configuration;
        }

        public async Task<List<SupplierProductValueObject>> GetItemsAsync()
        {
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync(Configuration.GetSection("SupplierProducts").Value))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<SupplierProductValueObject>>(apiResponse);
                }
            }
            throw new NotImplementedException();
        }



        public async Task<SupplierProductValueObject> GetItemByCodeAsync(string code)
        {
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync(Configuration.GetSection("SupplierProduct").Value + code))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<SupplierProductValueObject>(apiResponse);

                }
            }
            throw new NotImplementedException();
        }
        public async Task<List<SupplierCategoryValueObject>> GetCategoriesAsync()
        {
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync(Configuration.GetSection("SupplierCategories").Value))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<SupplierCategoryValueObject>>(apiResponse);
                    
                }
            }
            throw new NotImplementedException();
        }
    }
}
