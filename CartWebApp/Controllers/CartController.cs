using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CartWebApp.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
// inject the products list from the ProductsController
using static YourProjectName.Controllers.ProductsController;
using System.ComponentModel.Design;


using CartWebApp.Services; // Add this line to include the ProductService namespace









public static class SessionExtensions
{
    public static void SetObject(this ISession session, string key, object value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }

    public static T GetObject<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
    }
}


namespace CartWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ShoppingCart _cart;
        private readonly ProductService _productService;

        public CartController(ShoppingCart cart, ProductService productService)
        {
            _cart = cart;
            _productService = productService;
        }


        private const string CartSessionKey = "Cart";


        public IActionResult Index()
        {
            var cart = GetCart();
            Console.WriteLine("CartController Index");
            //Console.WriteLine(HttpContext.Session.GetObject<ShoppingCart>(CartSessionKey).Items.Count);
            Console.WriteLine(" about to return to Index");
            // loop through the cart items and log the product name and quantity
            foreach (var item in cart.Items)
            {
                Console.WriteLine($"Product: {item.Product.Name} Quantity: {item.Quantity}");
            }
            return View(cart);
        }

       public IActionResult AddToCart(int productId, int quantity)
{
    var cart = GetCart();
    Console.WriteLine($"Cart: {cart}    Cart Items: {cart.Items.Count}  Cart Total Price: {cart.TotalPrice}");
    Console.WriteLine("AddToCart");
    Console.WriteLine($"ProductId: {productId}");
    Console.WriteLine($"Quantity: {quantity}");

    Console.WriteLine("Products that exist:");
    foreach (var p in _productService.Products) // Use _productService to access products
    {
        Console.WriteLine($"Product: {p.Id} {p.Name} {p.Price}");
    }

    var product = _productService.Products.FirstOrDefault(p => p.Id == productId); // Use _productService to find the product
    if (product != null)
    {
        Console.WriteLine("AddToCart staring...");
        Console.WriteLine($"Product: {product}");
        Console.WriteLine($"Quantity: {quantity}");
        cart.AddItem(product, quantity);
        Console.WriteLine($"Cart Items: {cart.Items.Count}");
        Console.WriteLine($"Cart Total Price: {cart.TotalPrice}");

        SaveCart(cart);
    }
    else
    {
        Console.WriteLine("Product not found");
    }
    Console.WriteLine("AddToCart ending...");
    return RedirectToAction("Index");
}


        public IActionResult RemoveFromCart(int productId)
        {
            Console.WriteLine("RemoveFromCart");
            var cart = GetCart();
            cart.RemoveItem(productId);
            SaveCart(cart);
            return RedirectToAction("Index");
        }

        private ShoppingCart GetCart()
        {
            var cart = HttpContext.Session.GetObject<ShoppingCart>(CartSessionKey);
            if (cart == null)
            {
                cart = new ShoppingCart();
                SaveCart(cart);
            }
            return cart;

           
        }

        private void SaveCart(ShoppingCart cart)
        {
           // write code to  save shopping cart to session
            HttpContext.Session.SetObject(CartSessionKey, cart);




        }

        private void ClearCart()
        {
            HttpContext.Session.Remove(CartSessionKey);
        }

        // create a checkout method that takes user to checkout.cshtml
        public IActionResult Checkout()
        {
            var Cart = GetCart();
            return View();
        }   

    }
}
