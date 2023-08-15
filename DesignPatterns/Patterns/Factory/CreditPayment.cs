
using DesignPatterns.Patterns.Factory.Interfaces;

namespace DesignPatterns.Patterns.Factory;

public class CreditPayment : IPayment
{
    private decimal _interestRate; // Tasa de interés en decimal (por ejemplo, 0.05 para 5%)
    private decimal _fixedCommission; // Comisión fija en la moneda local

    public CreditPayment(decimal interestRate, decimal fixedCommission)
    {
        _interestRate = interestRate;
        _fixedCommission = fixedCommission;
    }

    public decimal Amount(decimal amount)
    {
        // Aplicar la tasa de interés al monto
        decimal amountWithInterest = amount * (1 + _interestRate);

        // Sumar la comisión fija
        decimal totalAmount = amountWithInterest + _fixedCommission;

        return totalAmount;
    }
}
