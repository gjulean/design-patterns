using DesignPatterns.Patterns.Strategy.Models;

namespace DesignPatterns.Patterns.Strategy.Interfaces;

public interface IStrategy
{
    public decimal GetAmount(Charge charge);
}
