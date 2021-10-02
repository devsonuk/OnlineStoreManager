using OnlineStoreManager.API.Services;
using OnlineStoreManager.Domain.Clients;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace OnlineStoreManager.API.Controllers
{
    [Authorize]
    public class SalesController : ApiController
    {
        private readonly SaleService _saleService;

        public SalesController()
        {
            _saleService = new SaleService();
        }

        [HttpGet]
        // GET: api/Sales
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        // GET: api/Sales/5
        public SaleModel Get(int id)
        {
            _saleService.Get(id);
            return new SaleModel();
        }

        [HttpPost]
        // POST: api/Sales
        public void Post([FromBody] List<SaleModel> sale)
        {
            _saleService.Add(sale, 1);
            Console.WriteLine(sale);
        }

        [HttpPut]
        // PUT: api/Sales/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sales/5
        public void Delete(int id)
        {
        }
    }
}
