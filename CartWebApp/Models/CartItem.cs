namespace CartWebApp.Models;

public class CartItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public decimal TotalPrice => Product.Price * Quantity;

    public CartItem(Product product, int quantity = 1)
    {
        Product = product ?? throw new ArgumentNullException(nameof(product));
        Quantity = quantity; // Assign the quantity parameter to the Quantity property
    }
}
