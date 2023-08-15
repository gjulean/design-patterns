using DesignPatterns.Patterns.Factory.Interfaces;

namespace DesignPatterns.Patterns.Factory;

public class CashPayment : IPayment
{
    private decimal _percentage;

    public CashPayment(decimal percentage)
    {
        _percentage = percentage;
    }

    public decimal Amount(decimal amount)
    {
        return amount * _percentage;
    }
}
