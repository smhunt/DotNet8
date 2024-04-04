using System.Collections.Generic;
using CartWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CartWebApp.Services;
public class ProductService
{
    private readonly AppDbContext _context;
    public List<Product> Products { get; private set; }

    public ProductService(AppDbContext context)
    {
        _context = context;
        LoadProducts();
    }

    private void LoadProducts()
    {
        Products = _context.Products.ToList();
    }
}
