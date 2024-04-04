using Microsoft.AspNetCore.Mvc;
using CartWebApp.Models;
using CartWebApp.Services; // Add this line to include the ProductService namespace

namespace YourProjectName.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.Products;
            return View(products);
        }
    }
}
