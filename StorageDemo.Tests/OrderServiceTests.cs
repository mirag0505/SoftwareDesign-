using Xunit;

public sealed class OrderServiceTests
{
    [Fact]
    public void ProcessOrder_CallsPaymentProcessor()
    {
        var fake = new FakePaymentProcessor();
        var service = new OrderService(fake);

        service.ProcessOrder(100m);

        Assert.True(fake.PaymentProcessed);
        Assert.Equal(100m, fake.LastAmount);
    }

    private sealed class FakePaymentProcessor : IPaymentProcessor
    {
        public bool PaymentProcessed { get; private set; }
        public decimal? LastAmount { get; private set; }

        public void ProcessPayment(decimal amount)
        {
            PaymentProcessed = true;
            LastAmount = amount;
        }
    }
}
