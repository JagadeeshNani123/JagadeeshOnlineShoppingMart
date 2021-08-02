using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.Controllers
{
    
    
    public class ProductController : Controller
    {

        public List<Product> products = new List<Product>()
        {
            new Product
            {
                Id=1,
                Name="IPhone",
                Cost=100000,
                Quantity=10
            },
            new Product
            {
                Id=2,
                Name="Samsung",
                Cost=70000,
                Quantity=100
            },
            new Product
            {
                Id=3,
                Name="Oppo",
                Cost=25000,
                Quantity=10
            },
            new Product
            {
                Id=4,
                Name="Vivo",
                Cost=35000,
                Quantity=10
            }
        };
        public IActionResult ListOfItems()
        {
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = products.First(p => p.Id == id);
            return View(product);
        }

        [HttpGet]
        public IActionResult AddTheItemToCart(int id)
        {
            var product = products.First(p => p.Id == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult AddTheItemToCart(Product modifiedProduct)
        {
            var product = products.First(p => p.Id == modifiedProduct.Id);
            var index = products.IndexOf(product);
            modifiedProduct.Id = product.Id;
            modifiedProduct.Name = product.Name;
            modifiedProduct.Cost = product.Cost;
            CustomerPortal.selectedItems.Add(modifiedProduct);
            var selectedProducts = CustomerPortal.selectedItems;
            var cost = 0m;
            foreach (var item in selectedProducts)
            {
                var quantity = item.Quantity;
                var productTotalCost = quantity * item.Cost;
                cost += productTotalCost;
            }
            ViewBag.Cost = cost;

            return View("AddedToCart", selectedProducts);
        }

        [HttpPost]
        public IActionResult AddedToCart(List<Product> selectedProducts)
        {
            
            return View("BuyNow", selectedProducts);
        }

        
        [HttpPost]
        public IActionResult BuyNow(List<Product> orderedProducts)
        {
            orderedProducts = CustomerPortal.selectedItems;
            
            return View("AddressPage");
        }

        [HttpGet]
        public IActionResult BuyNow()
        {
            var cost = 0m;
            var selectedProducts = CustomerPortal.selectedItems;
            foreach (var item in selectedProducts)
            {
                var quantity = item.Quantity;
                var productTotalCost = quantity * item.Cost;
                cost += productTotalCost;
            }
            ViewBag.Cost = cost;
            return View("BuyNow", selectedProducts);
        }

        public IActionResult Delete(int id)
        {
            var product = CustomerPortal.selectedItems.First(p => p.Id == id);
            var selectedProducts = CustomerPortal.selectedItems;
            selectedProducts.Remove(product);
            return View("AddedToCart", selectedProducts);
        }
        [HttpPost]
        public IActionResult AddressPage(IFormCollection collection)
        {
            var address = new AddressPage();
            address.FullName = collection["FullName"].ToString();
            address.MobileNumber = Convert.ToInt64(collection["MobileNumber"].ToString());
            address.Address = collection["Address"].ToString();
            address.Town = collection["Town"].ToString();
            address.PINCode= Convert.ToInt32(collection["PINCode"].ToString());
            DeliveryAddress.addressList.Add(address);
            return View("Payment");
        }

        [HttpPost]
        public IActionResult Payment(IFormCollection collection)
        {
            ViewBag.ItemsList = CustomerPortal.selectedItems;
            return View("ThankYou", DeliveryAddress.addressList.Last());
        }
    }
}
