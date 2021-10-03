﻿using Caliburn.Micro;
using OnlineStoreManager.DesktopUI.Library.Helpers;
using OnlineStoreManager.DesktopUI.Library.Models;
using OnlineStoreManager.DesktopUI.Library.Services;
using OnlineStoreManager.DesktopUI.Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreManager.DesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private readonly IProductService _productService;
        private readonly ISaleService _saleService;
        private readonly IConfigHelper _configHelper;

        public SalesViewModel(IProductService productEndPoint, IConfigHelper configHelper, ISaleService saleService)
        {
            _productService = productEndPoint;
            _saleService = saleService;
            _configHelper = configHelper;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();

        }

        private async Task LoadProducts()
        {
            var productList = await _productService.GetAll();
            var AvailableProds = productList.Where(p => p.QuantityInStock > 0).ToList();
            Products = new BindingList<ProductModel>(AvailableProds);
        }

        private BindingList<ProductModel> _products;

        public BindingList<ProductModel> Products
        {
            get => _products;
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private ProductModel _selectedProduct;

        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        private CartItemModel _selectedCartItem;

        public CartItemModel SelectedCartItem
        {
            get { return _selectedCartItem; }
            set
            {
                _selectedCartItem = value;
                NotifyOfPropertyChange(() => CanRemoveFromCart);
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        private BindingList<CartItemModel> _cart = new BindingList<CartItemModel>();

        public BindingList<CartItemModel> Cart
        {
            get => _cart;
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);

            }
        }

        private int _itemQuantity = 1;

        public int ItemQuantity
        {
            get => _itemQuantity;
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
                NotifyOfPropertyChange(() => CanAddToCart);
                NotifyOfPropertyChange(() => CanRemoveFromCart);
            }
        }

        private double _subTotal;
        private double _tax;
        private double _total;

        public string SubTotal
        {
            get
            {
                double subTotal = 0;

                foreach (CartItemModel item in Cart)
                {
                    subTotal += item.Product.RetailPrice * item.QuantityInCart;
                }

                _subTotal = subTotal;
                return subTotal.ToString("C");
            }
        }

        public string Tax
        {
            get
            {
                double taxAmount = 0;
                double taxRate = _configHelper.GetTaxRate() / 100;
                taxAmount = Cart.Where(c => c.Product.IsTaxable)
                    .Sum(c => c.Product.RetailPrice * c.QuantityInCart * taxRate);
                _tax = taxAmount;
                return taxAmount.ToString("C");
            }
        }

        public string Total
        {
            get
            {
                double total = _subTotal + _tax;
                _total = total;
                return total.ToString("C");
            }
        }

        // Make sure something is selected
        // Make Sure there is an item quantity
        public bool CanAddToCart => ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity;

        public void AddToCart()
        {

            var existingItem = Cart.FirstOrDefault(c => c.Product == SelectedProduct);
            int item_idx = Cart.IndexOf(existingItem);

            if (existingItem != null)
            {
                existingItem.QuantityInCart += ItemQuantity;
                Cart.Remove(existingItem);
                Cart.Insert(item_idx, existingItem);
            }
            else
            {
                var item = new CartItemModel
                {
                    Product = SelectedProduct,
                    QuantityInCart = ItemQuantity
                };
                Cart.Add(item);
            }
            SelectedProduct.QuantityInStock -= ItemQuantity;

            var existingProd = Products.FirstOrDefault(p => p.Id == SelectedProduct.Id);
            int prod_idx = Products.IndexOf(existingProd);
            if (existingProd != null)
            {
                Products.Remove(existingProd);
                Products.Insert(prod_idx, existingProd);
            }

            ItemQuantity = 1;
            NotifyOfPropertyChange(() => Cart);
            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
            NotifyOfPropertyChange(() => CanCheckOut);
            NotifyOfPropertyChange(() => Products);
        }

        public bool CanRemoveFromCart => ItemQuantity > 0 && SelectedCartItem?.QuantityInCart >= ItemQuantity;

        public void RemoveFromCart()
        {
            //Prod Side
            var existingItem = Products.FirstOrDefault(p => p == SelectedCartItem.Product);
            int item_idx = Products.IndexOf(existingItem);

            if (existingItem != null)
            {
                existingItem.QuantityInStock += ItemQuantity;
                Products.Remove(existingItem);
                Products.Insert(item_idx, existingItem);
            }

            //On Cart Side
            if (SelectedCartItem.QuantityInCart > ItemQuantity)
            {
                SelectedCartItem.QuantityInCart -= ItemQuantity;
                CartItemModel temp = new CartItemModel { Product = SelectedCartItem.Product, QuantityInCart = SelectedCartItem.QuantityInCart }; 
                int cart_idx = Cart.IndexOf(SelectedCartItem);
                Cart.Remove(SelectedCartItem);
                Cart.Insert(cart_idx, temp);
            }
            else if (SelectedCartItem.QuantityInCart == ItemQuantity)
            {
                SelectedCartItem.QuantityInCart -= ItemQuantity;
                int cart_idx = Cart.IndexOf(SelectedCartItem);
                Cart.RemoveAt(cart_idx);
            }

            ItemQuantity = 1;
            NotifyOfPropertyChange(() => Products);
            NotifyOfPropertyChange(() => Cart);
            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
            NotifyOfPropertyChange(() => CanCheckOut);
        }

        // Make sure there is something in the cart
        public bool CanCheckOut => Cart.Count > 0;

        public async Task CheckOut()
        {
            List<SaleModel> sale = Cart.Select(c => new SaleModel { ProductId = c.Product.Id, Quantity = c.QuantityInCart }).ToList();

            int saleId = await _saleService.AddAsync(sale);

            await LoadProducts();
            Cart.Clear();
        }

    }
}
