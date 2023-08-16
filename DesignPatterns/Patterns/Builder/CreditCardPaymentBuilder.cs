using DesignPatterns.Patterns.Builder.Interfaces;
using DesignPatterns.Patterns.Builder.Models;

namespace DesignPatterns.Patterns.Builder;

public class CreditCardPaymentBuilder : IPaymentBuilder
{
    private double _amount;
    private string _currency;
    private string _paymentMethod;
    private string _customerName;
    private string _email;

    public void SetAmount(double amount)
    {
        _amount = amount;
    }

    public void SetCurrency(string currency)
    {
        _currency = currency;
    }

    public void SetCustomerInfo(string customerName, string email)
    {
        _customerName = customerName;
        _email = email;
    }

    public void SetPaymentMethod(string paymentMethod)
    {
        _paymentMethod = paymentMethod;
    }

    public CreditCardPayment Build()
    {
        return new CreditCardPayment
        {
            Amount = _amount,
            Currency = _currency,
            PaymentMethod = _paymentMethod,
            CustomerName = _customerName,
            Email = _email
        };
    }
}

