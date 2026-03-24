public sealed class BankAccount
{
    private double _balance;

    public BankAccount(double initialBalance)
    {
        _balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        _balance += amount;
    }

    public void Withdraw(double amount)
    {
        _balance -= amount;
    }

    public double GetBalance()
    {
        return _balance;
    }
}
