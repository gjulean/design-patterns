using Microsoft.Extensions.DependencyInjection;

namespace DesignPatterns.Patterns.Factory;

public class PaymentProcessor
{
    private readonly IServiceProvider _serviceProvider;

    public PaymentProcessor(decimal percentage, decimal interestRate, decimal fixedCommission)
    {
        _serviceProvider = new ServiceCollection()
            .AddTransient<PaymentFactory, CashPaymentFactory>(provider => new CashPaymentFactory(percentage))
            .AddTransient<PaymentFactory, CreditPaymentFactory>(provider => new CreditPaymentFactory(interestRate, fixedCommission))
            .BuildServiceProvider();
    }

    public decimal ProcessCashPayment(decimal amountToPay)
    {
        var cashPaymentFactory = _serviceProvider.GetRequiredService<PaymentFactory>();
        var paymentCash = cashPaymentFactory.GetAmount();
        return paymentCash.Amount(amountToPay);
    }

    public decimal ProcessCreditPayment(decimal amountToPay)
    {
        var creditPaymentFactory = _serviceProvider.GetRequiredService<PaymentFactory>();
        var paymentCredit = creditPaymentFactory.GetAmount();
        return paymentCredit.Amount(amountToPay);
    }
}
