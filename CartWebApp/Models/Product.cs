namespace CartWebApp.Models;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; }  = string.Empty;
    //public string Category { get; set; } = string.Empty;
    // Additional properties like ImageUrl, StockQuantity, etc.
    public string Image_Url { get; set; } = string.Empty;
    
    
    
}
