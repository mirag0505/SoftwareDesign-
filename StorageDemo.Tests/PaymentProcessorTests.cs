using Xunit;

public sealed class PaymentProcessorTests
{
    [Fact]
    public void CreditCardProcessor_DoesNotThrow()
    {
        IPaymentProcessor processor = new CreditCardProcessor();
        var exception = Record.Exception(() => processor.ProcessPayment(100m));
        Assert.Null(exception);
    }

    [Fact]
    public void PayPalProcessor_DoesNotThrow()
    {
        IPaymentProcessor processor = new PayPalProcessor();
        var exception = Record.Exception(() => processor.ProcessPayment(200m));
        Assert.Null(exception);
    }

    [Fact]
    public void BankTransferProcessor_DoesNotThrow()
    {
        IPaymentProcessor processor = new BankTransferProcessor();
        var exception = Record.Exception(() => processor.ProcessPayment(300m));
        Assert.Null(exception);
    }
}
