﻿using OnlineStoreManager.API.Helpers;
using OnlineStoreManager.Domain.Clients;
using OnlineStoreManager.Domain.Entities;
using OnlineStoreManager.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OnlineStoreManager.API.Services
{
    public class SaleService
    {
        private GenericRepository<Product> _productRepository;
        private GenericRepository<Sale> _saleRepository;
        private GenericRepository<SaleDetail> _saleDetailRepository;

        public SaleService()
        {
            _productRepository = new GenericRepository<Product>("OnlineStoreManager");
            _saleRepository = new GenericRepository<Sale>("OnlineStoreManager");
            _saleDetailRepository = new GenericRepository<SaleDetail>("OnlineStoreManager");
        }
        public void Add(List<SaleModel> saleInfo, int cashierId)
        {
            decimal taxRate = (decimal)(ConfigHelper.GetTaxRate() / 100);
            List<SaleDetail> details = new List<SaleDetail>();

            saleInfo.ForEach(s =>
            {
                SaleDetail detail = new SaleDetail
                {
                    ProductId = s.ProductId,
                    Quantity = s.Quantity,
                    CreatedAt = DateTime.Now
                };

                // Collect info
                Product prodInfo = _productRepository.Get(detail.ProductId);

                if (prodInfo == null)
                {
                    throw new Exception($"The product Id of {detail.ProductId} could not found in database.");
                }

                detail.CumulativePrice = prodInfo.RetailPrice * detail.Quantity;

                if (prodInfo.IsTaxable)
                {
                    detail.Tax = detail.CumulativePrice * taxRate;
                }
                details.Add(detail);
            });

            decimal subTotal = details.Sum(d => d.CumulativePrice);
            decimal tax = details.Sum(d => d.Tax);
            Sale sale = new Sale
            {
                CashierId = cashierId,
                SubTotal = subTotal,
                Tax = tax,
                Total = subTotal + tax,
                CreatedAt = DateTime.Now
            };

            int saleId = _saleRepository.Add(sale);

            details.ForEach(sd =>
            {
                sd.SaleId = saleId;
                _ = _saleDetailRepository.Add(sd);
            });

        }

        public Sale Get(int id)
        {
            Sale sale = _saleRepository.Get(id);
            return sale;
        }
    }
}