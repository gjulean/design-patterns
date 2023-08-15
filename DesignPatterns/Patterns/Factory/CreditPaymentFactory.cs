using DesignPatterns.Patterns.Factory.Interfaces;

namespace DesignPatterns.Patterns.Factory
{
    public class CreditPaymentFactory : PaymentFactory
    {
        private decimal _interestRate; // Tasa de interés en decimal (por ejemplo, 0.05 para 5%)
        private decimal _fixedCommission; // Comisión fija en la moneda local

        public CreditPaymentFactory(decimal interestRate, decimal fixedCommission)
        {
            _interestRate = interestRate;
            _fixedCommission = fixedCommission;
        }

        public override IPayment GetAmount()
        {
            return new CreditPayment(_interestRate, _fixedCommission);
        }
    }

}
