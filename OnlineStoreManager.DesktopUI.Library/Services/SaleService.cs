using OnlineStoreManager.DesktopUI.Library.Helpers;
using OnlineStoreManager.DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreManager.DesktopUI.Library.Services
{
    public class SaleService : ISaleService
    {
        private IApiHelper _apiHelper;

        public SaleService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<bool> AddAsync(List<SaleModel> sale)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync($"api/sales", sale))
            {
                if (response.IsSuccessStatusCode)
                {
                    // Log success ?
                    return true;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
