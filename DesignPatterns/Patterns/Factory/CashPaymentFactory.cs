using DesignPatterns.Patterns.Factory.Interfaces;

namespace DesignPatterns.Patterns.Factory;

public class CashPaymentFactory : PaymentFactory
{
    private decimal _percentage;

    public CashPaymentFactory(decimal percentage)
    {
        _percentage = percentage;
    }

    public override IPayment GetAmount()
    {
        return new CashPayment(_percentage);
    }
}
