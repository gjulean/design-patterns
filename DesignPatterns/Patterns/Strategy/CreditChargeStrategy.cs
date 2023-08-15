using DesignPatterns.Patterns.Strategy.Interfaces;
using DesignPatterns.Patterns.Strategy.Models;

namespace DesignPatterns.Patterns.Strategy;

public class CreditChargeStrategy : IStrategy
{
    public decimal GetAmount(Charge charge)
    {
        return charge.Total * 1.5m;
    }
}
