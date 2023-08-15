using DesignPatterns.Patterns.Strategy.Interfaces;
using DesignPatterns.Patterns.Strategy.Models;

namespace DesignPatterns.Patterns.Strategy;

public class ChargeContext
{
    private IStrategy _strategy;

    public IStrategy Strategy
    {
        set { _strategy = value; }
    }

    public ChargeContext(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public decimal GetAmount(Charge charge)
    {
        return _strategy.GetAmount(charge);
    }
}
