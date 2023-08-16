using DesignPatterns.Patterns.Builder.Models;

namespace DesignPatterns.Patterns.Builder.Interfaces;

public interface IPaymentBuilder
{
    void SetAmount(double amount);
    void SetCurrency(string currency);
    void SetPaymentMethod(string paymentMethod);
    void SetCustomerInfo(string customerName, string email);
    CreditCardPayment Build();
}
