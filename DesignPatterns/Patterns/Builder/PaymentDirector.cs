using DesignPatterns.Patterns.Builder.Models;

namespace DesignPatterns.Patterns.Builder;

public class PaymentDirector
{
    private CreditCardPaymentBuilder _paymentBuilder;

    public PaymentDirector(CreditCardPaymentBuilder paymentBuilder)
    {
        _paymentBuilder = paymentBuilder;
    }

    public CreditCardPayment ConstructPayment(double amount, string currency, string paymentMethod, string customerName, string email)
    {
        _paymentBuilder.SetAmount(amount);
        _paymentBuilder.SetCurrency(currency);
        _paymentBuilder.SetPaymentMethod(paymentMethod);
        _paymentBuilder.SetCustomerInfo(customerName, email);
        return _paymentBuilder.Build();
    }
}
