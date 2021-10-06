using OnlineStoreManager.DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreManager.DesktopUI.Library.Helpers
{
    public class ApiHelper : IApiHelper
    {
        private HttpClient _apiClient;
        private ILoggedUserModel _loggedInUser;

        public ApiHelper(ILoggedUserModel loggedInUserModel)
        {
            InitializeClient();
            _loggedInUser = loggedInUserModel;
        }

        public HttpClient ApiClient => _apiClient;

        private void InitializeClient()
        {
            var api = ConfigurationManager.AppSettings.Get("api");

            _apiClient = new HttpClient
            {
                BaseAddress = new Uri(api)
            };
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticatedUserModel> AuthenticateAsync(string userName, string password)
        {
            var data = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password)
            });

            using (var response = await _apiClient.PostAsync("/Token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AuthenticatedUserModel>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task FetchLoggedUser(string token)
        {
            _apiClient.DefaultRequestHeaders.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            using (var response = await _apiClient.GetAsync("api/Users"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<LoggedUserModel>();
                    _loggedInUser.Id = result.Id;
                    _loggedInUser.FirstName = result.FirstName;
                    _loggedInUser.LastName = result.LastName;
                    _loggedInUser.Email = result.Email;
                    _loggedInUser.CreatedAt = result.CreatedAt;
                    _loggedInUser.UpdatedAt = result.UpdatedAt;
                    _loggedInUser.AccessToken = token;
                }
            }
        }

        public void Clear()
        {
            _apiClient.DefaultRequestHeaders.Clear();
        }
    }
}
