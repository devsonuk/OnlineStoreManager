using OOnlineStoreManager.UILibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OnlineStoreManager.UILibrary.Models
{
    public class ApiHelper : IApiHelper
    {
        private HttpClient _apiClient;
        private ILoggedInUserModel _loggedInUser;

        public ApiHelper(ILoggedInUserModel loggedInUserModel)
        {
            InitializeClient();
            _loggedInUser = loggedInUserModel;
        }

        private void InitializeClient()
        {
            var api = ConfigurationManager.AppSettings.Get("api");

            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(api);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticatedUser> AuthenticateAsync(string userName, string password)
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
                    var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
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
                    var result = await response.Content.ReadAsAsync<LoggedInUserModel>();
                    _loggedInUser.FirstName = result.FirstName;
                    _loggedInUser.LastName = result.LastName;
                    _loggedInUser.EmailAddress = result.EmailAddress;
                    _loggedInUser.CreatedAt = result.CreatedAt;
                    _loggedInUser.UpdatedAt = result.UpdatedAt;
                    _loggedInUser.AccessToken = token;
                }
            }
        }
    }
}
