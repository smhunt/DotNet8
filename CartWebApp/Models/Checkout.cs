using CartWebApp.Controllers;

public class Checkout
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public string Email { get; set; }
    public string Phone { get; set; }
    public string CreditCard { get; set; }
    public string Expiration { get; set; }
    public string CVV { get; set; }

    public CartController Cart { get; set; }
}