using OnlineStoreManager.Domain.Entities;
using OnlineStoreManager.Repository.Generic;
using System.Collections.Generic;
using System.Web.Http;

namespace OnlineStoreManager.API.Controllers
{
    [Authorize]
    public class ProductsController : ApiController
    {
        private readonly GenericRepository<Product> _productRepository;

        public ProductsController()
        {
            _productRepository = new GenericRepository<Product>("OnlineStoreManager");
        }

        // GET: api/Products
        public IEnumerable<Product> Get()
        {
            var data = _productRepository.GetAll();
            return data ;
        }

        // GET: api/Products/5
        public Product Get(int id)
        {
            var data = _productRepository.Get(id);
            return data;
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
