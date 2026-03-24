using System;

public sealed class OrderService
{
    private readonly IPaymentProcessor _paymentProcessor;

    public OrderService(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }

    public void ProcessOrder(decimal amount)
    {
        Console.WriteLine("Processing order...");
        _paymentProcessor.ProcessPayment(amount);
        Console.WriteLine("Order processed.");
    }
}
