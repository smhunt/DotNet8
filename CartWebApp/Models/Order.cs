namespace CartWebApp.Models;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public List<CartItem> Items { get; set; } = new List<CartItem>();
    public decimal TotalPrice => Items.Sum(i => i.TotalPrice);

    public Order(string customerName, string customerEmail)
    {
        CustomerName = customerName ?? throw new ArgumentNullException(nameof(customerName));
        CustomerEmail = customerEmail ?? throw new ArgumentNullException(nameof(customerEmail));
    }
}
