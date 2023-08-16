
namespace DesignPatterns.Patterns.Builder.Models;

public class CreditCardPayment
{
    public double Amount { get; set; }
    public string Currency { get; set; }
    public string PaymentMethod { get; set; }
    public string CustomerName { get; set; }
    public string Email { get; set; }
}
