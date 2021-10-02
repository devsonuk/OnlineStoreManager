using OnlineStoreManager.DesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoreManager.DesktopUI.Library.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductModel> Get(int id);
        Task<List<ProductModel>> GetAll();
    }
}