using OnlineStoreManager.DesktopUI.Library.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineStoreManager.DesktopUI.Library.Helpers
{
    public interface IApiHelper
    {
        HttpClient ApiClient { get; }

        Task<AuthenticatedUserModel> AuthenticateAsync(string userName, string password);
        void Clear();
        Task FetchLoggedUser(string token);
    }
}