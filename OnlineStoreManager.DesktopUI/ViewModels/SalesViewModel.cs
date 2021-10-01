using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreManager.DesktopUI.ViewModels
{
    //public class SalesViewModel : Screen
    //{
    //    private IProductEndPoint _productEndPoint;
    //    private readonly IConfigHelper _configHelper;

    //    public SalesViewModel(IProductEndPoint productEndPoint, IConfigHelper configHelper)
    //    {
    //        _productEndPoint = productEndPoint;
    //        _configHelper = configHelper;
    //    }

    //    protected override async void OnViewLoaded(object view)
    //    {
    //        base.OnViewLoaded(view);
    //        await LoadProducts();

    //    }

    //    private async Task LoadProducts()
    //    {
    //        var productList = await _productEndPoint.GetAll();
    //        Products = new BindingList<ProductModel>(productList);
    //    }

    //    private BindingList<ProductModel> _products;

    //    public BindingList<ProductModel> Products
    //    {
    //        get => _products;
    //        set
    //        {
    //            _products = value;
    //            NotifyOfPropertyChange(() => Products);
    //        }
    //    }

    //    private ProductModel _selectedProduct;

    //    public ProductModel SelectedProduct
    //    {
    //        get { return _selectedProduct; }
    //        set
    //        {
    //            _selectedProduct = value;
    //            NotifyOfPropertyChange(() => SelectedProduct);
    //            NotifyOfPropertyChange(() => CanAddToCart);
    //        }
    //    }

    //    private BindingList<CartItemModel> _cart = new BindingList<CartItemModel>();

    //    public BindingList<CartItemModel> Cart
    //    {
    //        get => _cart;
    //        set
    //        {
    //            _cart = value;
    //            NotifyOfPropertyChange(() => Cart);

    //        }
    //    }

    //    private int _itemQuantity = 1;

    //    public int ItemQuantity
    //    {
    //        get => _itemQuantity;
    //        set
    //        {
    //            _itemQuantity = value;
    //            NotifyOfPropertyChange(() => ItemQuantity);
    //            NotifyOfPropertyChange(() => CanAddToCart);
    //        }
    //    }

    //    private double _subTotal;
    //    private double _tax;
    //    private double _total;

    //    public string SubTotal
    //    {
    //        get
    //        {
    //            double subTotal = 0;

    //            foreach (var item in Cart)
    //            {
    //                subTotal += (item.Product.RetailPrice * item.QuantityInCart);
    //            }

    //            _subTotal = subTotal;
    //            return subTotal.ToString("C");
    //        }
    //    }

    //    public string Tax
    //    {
    //        get
    //        {
    //            double taxAmount = 0;
    //            var taxRate = _configHelper.GetTaxRate();

    //            foreach (var item in Cart)
    //            {
    //                if (item.Product.IsTaxable)
    //                {
    //                    taxAmount += (item.Product.RetailPrice * item.QuantityInCart * taxRate) / 100;

    //                }
    //            }
    //            _tax = taxAmount;
    //            return taxAmount.ToString("C");
    //        }
    //    }

    //    public string Total
    //    {
    //        get
    //        {
    //            var total = _subTotal + _tax;
    //            _total = total;
    //            return total.ToString("C");
    //        }
    //    }

    //    public bool CanAddToCart
    //    {
    //        get
    //        {

    //            // Make sure something is selected
    //            // Make Sure there is an item quantity
    //            if (ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity)
    //            {
    //                return true;
    //            }

    //            return false;
    //        }
    //    }

    //    public void AddToCart()
    //    {

    //        var existingItem = Cart.FirstOrDefault(c => c.Product == SelectedProduct);

    //        if (existingItem != null)
    //        {
    //            existingItem.QuantityInCart += ItemQuantity;
    //            Cart.Remove(existingItem);
    //            Cart.Add(existingItem);
    //        }
    //        else
    //        {
    //            var item = new CartItemModel
    //            {
    //                Product = SelectedProduct,
    //                QuantityInCart = ItemQuantity
    //            };
    //            Cart.Add(item);
    //        }
    //        SelectedProduct.QuantityInStock -= ItemQuantity;
    //        ItemQuantity = 1;
    //        NotifyOfPropertyChange(() => Cart);
    //        NotifyOfPropertyChange(() => SubTotal);
    //        NotifyOfPropertyChange(() => Tax);
    //        NotifyOfPropertyChange(() => Total);
    //    }

    //    public bool CanRemoveFromCart
    //    {
    //        get
    //        {
    //            var output = false;

    //            // Make sure something is selected

    //            return output;
    //        }
    //    }

    //    public void RemoveFromCart()
    //    {


    //        NotifyOfPropertyChange(() => SubTotal);
    //        NotifyOfPropertyChange(() => Tax);
    //        NotifyOfPropertyChange(() => Total);
    //    }

    //    public bool CanCheckOut
    //    {
    //        get
    //        {
    //            var output = false;

    //            // Make sure there is something in the cart

    //            return output;
    //        }
    //    }

    //    public void CheckOut()
    //    {

    //    }

    //}

    public class SalesViewModel : Screen
    {

    }

}
