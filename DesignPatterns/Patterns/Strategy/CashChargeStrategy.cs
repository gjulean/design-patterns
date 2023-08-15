using DesignPatterns.Patterns.Strategy.Interfaces;
using DesignPatterns.Patterns.Strategy.Models;

namespace DesignPatterns.Patterns.Strategy;

public class CashChargeStrategy : IStrategy
{
    public decimal GetAmount(Charge charge)
    {
        return charge.Total;
    }
}
