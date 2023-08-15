using DesignPatterns.DataAccess;
using DesignPatterns.Patterns.Factory;
using DesignPatterns.Patterns.Repository;
using DesignPatterns.Patterns.Singleton;
using DesignPatterns.Patterns.Strategy;
using DesignPatterns.Patterns.Strategy.Models;
using DesignPatterns.Patterns.UnitOfWork;

//PATRONES DE DISEÑO

#region Singleton

SingletonLogger.DemonstrateSingletonWithoutLock();
SingletonLogger.DemonstrateSingletonWithLock();

Console.ReadKey();

#endregion

#region Factory Method

var percentage = 0.50m;
var interestRate = 1.2m;
var fixedCommission = 100;
decimal amountToPay = 100;

//La clase PaymentProcessor implementa el patron de diseño de Dependency Injection
var paymentProcessor = new PaymentProcessor(percentage, interestRate, fixedCommission);
decimal cashPaymentAmount = paymentProcessor.ProcessCashPayment(amountToPay);
decimal creditPaymentAmount = paymentProcessor.ProcessCreditPayment(amountToPay);

Console.WriteLine($"Cash Payment Amount: {cashPaymentAmount}");
Console.WriteLine($"Credit Payment Amount: {creditPaymentAmount}");

Console.WriteLine();
Console.WriteLine("------------------------------------");
Console.WriteLine();

Console.ReadKey();

#endregion

#region Repository

var useRepository = false;

if (useRepository)
{
    using (var context = new DesignPatternsContext())
    {
        var repositoryDataSeeder = new RepositoryDataSeeder(context);
        repositoryDataSeeder.SeedData();
        repositoryDataSeeder.DisplayData();
    }

    Console.ReadKey();
}

#endregion

#region UnitOfWork

var useUnitOFWork = false;

if (useUnitOFWork)
{
    using (var context = new DesignPatternsContext())
    {
        var unitOfWork = new UnitOfWorkDataSeeder(context);
        unitOfWork.SeedData();
        unitOfWork.DisplayData();
    }

    Console.ReadKey();
}

#endregion

#region Strategy

Console.WriteLine();

var strategyContext = new ChargeContext(new CashChargeStrategy());

var charge = new Charge() { Total = 50 };
Console.WriteLine($"El valor del pago en efecto para el cargo es de {strategyContext.GetAmount(charge)}");
Console.WriteLine();

strategyContext.Strategy = new CreditChargeStrategy();
Console.WriteLine($"El valor del pago en credito para el cargo es de {strategyContext.GetAmount(charge)}");
Console.WriteLine();

Console.ReadKey();

#endregion