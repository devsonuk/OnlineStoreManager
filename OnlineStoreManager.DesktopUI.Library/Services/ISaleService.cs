using OnlineStoreManager.DesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoreManager.DesktopUI.Library.Services
{
    public interface ISaleService
    {
        Task<int> AddAsync(List<SaleModel> sale, int id);
    }
}