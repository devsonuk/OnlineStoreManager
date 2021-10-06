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

        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        [Route("api/sales/report")]
        // GET: api/Sales
        public List<SaleReport> GetSalesReport()
        {
            if (RequestContext.Principal.IsInRole("Admin"))
            {
                // Do Admin stuffs
                return _saleService.GetReport();
            }
            else if (RequestContext.Principal.IsInRole("Manager"))
            {
                // Do Admin stuffs
                return _saleService.GetReport();

            }
            else
            {
                return _saleService.GetReport();
            }
        }

        [HttpGet]
        // GET: api/Sales/5
        public Sale Get(int id)
        {
            var sale = _saleService.Get(id);
            return sale;
        }

        [Authorize(Roles = "Cashier")]
        [HttpPost]
        [Route("api/sales/user/{userId}")]
        // POST: api/Sales
        public IHttpActionResult Post([FromBody] List<SaleModel> sale, [FromUri] int userId)
        {
            var saleId = _saleService.Add(sale, userId);
            return Ok(new { Id = saleId });
        }

        [HttpPut]
        // PUT: api/Sales/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Sales/5
        public void Delete(int id)
        {
        }
    }
}
