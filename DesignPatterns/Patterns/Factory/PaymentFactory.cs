using DesignPatterns.Patterns.Factory.Interfaces;

namespace DesignPatterns.Patterns.Factory;

public abstract class PaymentFactory
{
    public abstract IPayment GetAmount();
}
