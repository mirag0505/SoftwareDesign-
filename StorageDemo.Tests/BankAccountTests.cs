using System;
using Xunit;

public sealed class BankAccountTests
{
    [Fact]
    public void Deposit_IncreasesBalance()
    {
        var account = new BankAccount(1000);

        account.Deposit(500);

        Assert.Equal(1500, account.GetBalance());
    }

    [Fact]
    public void Withdraw_DecreasesBalance()
    {
        var account = new BankAccount(1000);

        account.Withdraw(200);

        Assert.Equal(800, account.GetBalance());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Deposit_NonPositive_Throws(double amount)
    {
        var account = new BankAccount(1000);

        Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(amount));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Withdraw_NonPositive_Throws(double amount)
    {
        var account = new BankAccount(1000);

        Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(amount));
    }

    [Fact]
    public void Withdraw_TooMuch_Throws()
    {
        var account = new BankAccount(1000);

        Assert.Throws<InvalidOperationException>(() => account.Withdraw(2000));
        Assert.Equal(1000, account.GetBalance());
    }
}
