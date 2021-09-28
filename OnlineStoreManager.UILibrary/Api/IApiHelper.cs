using OOnlineStoreManager.UILibrary.Models;
using System.Threading.Tasks;

namespace OnlineStoreManager.UILibrary.Models
{
    public interface IApiHelper
    {
        Task<AuthenticatedUser> AuthenticateAsync(string userName, string password);

        Task FetchLoggedUser(string token);
    }
}