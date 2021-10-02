using OnlineStoreManager.DesktopUI.Library.Helpers;
using OnlineStoreManager.DesktopUI.Library.Models;
using OnlineStoreManager.DesktopUI.Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreManager.DesktopUI.Library.Services
{
    public class ProductService : IProductService
    {
        private IApiHelper _apiHelper;

        public ProductService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            using (var response = await _apiHelper.ApiClient.GetAsync("api/Products"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<ProductModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async Task<ProductModel> Get(int id)
        {
            using (var response = await _apiHelper.ApiClient.GetAsync($"api/Products/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<ProductModel>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
