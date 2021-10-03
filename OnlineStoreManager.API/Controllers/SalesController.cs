using OnlineStoreManager.API.Services;
using OnlineStoreManager.Domain.Clients;
using OnlineStoreManager.Domain.Entities;
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
        public Sale Get(int id)
        {
            var sale = _saleService.Get(id);
            return sale;
        }

        [HttpPost]
        // POST: api/Sales
        public IHttpActionResult Post([FromBody] List<SaleModel> sale)
        {
            var saleId = _saleService.Add(sale, 1);
            return Ok(new { Id = saleId });
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
