using OnlineStoreManager.Domain.Entities;
using OnlineStoreManager.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineStoreManager.API.Controllers
{
    [Authorize]
    public class InventoriesController : ApiController
    {
        private readonly GenericRepository<Inventory> _inventoryRepository;

        public InventoriesController()
        {
            _inventoryRepository = new GenericRepository<Inventory>("OnlineStoreManager");
        }

        [Authorize(Roles ="Manager")]
        // GET: api/Inventories
        public List<Inventory> Get()
        {
            return _inventoryRepository.GetAll().ToList();
        }

        [Authorize(Roles = "Manager")]
        // GET: api/Inventories/5
        public Inventory Get(int id)
        {
            return _inventoryRepository.Get(id);
        }

        [Authorize(Roles = "Admin")]
        // POST: api/Inventories
        public int Post([FromBody]Inventory inventory)
        {
            return _inventoryRepository.Add(inventory);
        }

        // PUT: api/Inventories/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Inventories/5
        public void Delete(int id)
        {
        }
    }
}
