using OnlineStoreManager.DesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoreManager.DesktopUI.Library.Services
{
    public interface ISaleService
    {
        Task<bool> AddAsync(List<SaleModel> sale);
    }
}