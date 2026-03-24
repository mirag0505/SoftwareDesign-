using System;

public sealed class BankTransferProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing bank transfer payment of ${amount}");
    }
}
